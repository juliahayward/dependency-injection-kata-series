﻿using DependencyInjection.Console.CharacterWriters;
using DependencyInjection.Console.Entities;

namespace DependencyInjection.Console
{
    internal class PatternWriter
    {
        private readonly ICharacterWriter _characterWriter;

        public PatternWriter(bool useColours)
        {
            var writer = new AsciiWriter();
            _characterWriter = useColours ? (ICharacterWriter) new ColorWriter(writer) : writer;
        }

        public void Write(Pattern pattern)
        {
            var squares = pattern.Squares;

            for (var j = 0; j < squares.GetLength(0); ++j)
            {
                for (var i = 0; i < squares.GetLength(1); ++i)
                {
                    _characterWriter.Write(squares[j, i]);
                }
                _characterWriter.WriteLine();
            }
        }
    }
}