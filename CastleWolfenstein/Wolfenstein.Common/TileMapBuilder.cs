﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Wolfenstein.Common
{
    /// <summary>
    /// Builds a Bitmap image from a char[,] map and
    /// a Dictionary that contains the bitmap to use for each char.
    /// </summary>
    public class TileMapBuilder
    {
        private Bitmap mapImage;

        public TileMapBuilder(TileType[,] map, Dictionary<TileType, Bitmap> dictionary, int tileSize)
        {
            int mapRows = map.GetLength(0);
            int mapCols = map.GetLength(1);

            mapImage = new Bitmap(mapCols * tileSize, mapRows * tileSize);
            Graphics mapGraphics = Graphics.FromImage(mapImage);

            Bitmap tile;
            for (int row = 0; row < mapRows; row++)
            {
                for (int col = 0; col < mapCols; col++)
                {
                    tile = dictionary[map[row, col]];
                    int x = col * tileSize;
                    int y = row * tileSize;
                    mapGraphics.DrawImage(tile, x, y, tileSize, tileSize);
                }
            }
        }

        public Bitmap ToImage()
        {
            return mapImage;
        }
    }
}