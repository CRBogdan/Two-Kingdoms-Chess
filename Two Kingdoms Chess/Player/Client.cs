using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace Two_Kingdoms_Chess
{
    public class Client : Player
    {
        private TcpClient client;
        public void setClient(TcpClient client)
        {
            this.client = client;
        }

        public override void onPlayerMove(Move move)
        {
            NetworkStream stream = client.GetStream();

            string moveJSON = JsonConvert.SerializeObject(new MoveDTO(move));

            byte[] data = Encoding.UTF8.GetBytes(moveJSON);

            stream.WriteAsync(data);

            waitForPlayer();
        }

        public async void waitForPlayer()
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];

            await stream.ReadAsync(buffer);

            string json = Encoding.UTF8.GetString(buffer);

            MoveDTO moveDTO = JsonConvert.DeserializeObject<MoveDTO>(json);

            Move move = makeMove(game.gameTable[moveDTO.oldPositionX, moveDTO.oldPositionY], new Position(moveDTO.newPositionX, moveDTO.newPositionY));

            game.movePiece(this, move);
        }
    }
}
