namespace Two_Kingdoms_Chess
{
    public class MoveNode
    {
        public List<MoveNode> moveNodes;
        public List<Move> moves;

        public MoveNode(List<MoveNode> moveTrees, List<Move> moves)
        {
            this.moveNodes = moveTrees;
            this.moves = moves;
        }

        public List<Move> getMovesList()
        {
            List<Move> movesToReturn = new List<Move>();
            if (moves != null)
                movesToReturn.AddRange(moves);

            if (moveNodes == null)
                return movesToReturn;

            foreach (var m in moveNodes)
            {
                var mo = m.getMovesList();
                movesToReturn.AddRange(mo);
            }

            return movesToReturn;
        }
    }
}
