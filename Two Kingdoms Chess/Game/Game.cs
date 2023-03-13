using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Player;

namespace Two_Kingdoms_Chess.Game
{
    public class Game
    {
        public Player.Player playerOne;
        public Player.Player playerTwo;

        public Game(Player.Player playerOne, Player.Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public void movePiece(Player.Player player, Move.Move move)
        {
            if(player == playerOne)
            {
                playerTwo.onPlayerMove(move);
            }else
            {
                playerOne.onPlayerMove(move);
            }
        }
    }                            
}
