﻿namespace Two_Kingdoms_Chess
{
    public abstract class ColoredPiece
    {
        public Piece piece;
        public String color;

        public abstract String getPieceColor();

        public List<Move> getMoves(ColoredPiece[,] table)
        {
            return piece.getPossibleMoves(table, color);
        }
    }
}
