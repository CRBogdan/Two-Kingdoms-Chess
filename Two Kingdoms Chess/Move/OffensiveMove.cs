﻿namespace Two_Kingdoms_Chess
{
    public class OffensiveMove : Move
    {
        public OffensiveMove(Piece piece, Position position) : base(piece, position)
        {
            this.color = "red";
        }
    }
}
