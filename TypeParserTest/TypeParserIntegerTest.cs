﻿using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using ThrowException.CSharpLibs.TypeParserLib;

namespace ThrowException.CSharpLibs.TypeParserTest
{
    [TestFixture()]
    public class TypeParserIntegerTest
    {
        [Test()]
        public void TryParse()
        {
            Assert.True(TypeParsers.TryParse("0", out short v1));
            Assert.AreEqual(v1, 0);
            Assert.True(TypeParsers.TryParse("1", out short v2));
            Assert.AreEqual(v2, 1);
            Assert.True(TypeParsers.TryParse("-1", out short v3));
            Assert.AreEqual(v3, -1);
            Assert.False(TypeParsers.TryParse("xx", out short v4));
        }

        [Test()]
        public void ParseFail()
        {
            {
                var parser = new TypeParserSbyte();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserInt16();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserInt32();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserInt64();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserByte();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserUint16();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserUint32();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }

            {
                var parser = new TypeParserUint64();
                Assert.Throws<ValueParseException>(() => parser.Parse("xx"));
                Assert.Throws<ValueParseException>(() => parser.Parse("§§"));
            }
        }

        [Test()]
        public void Parse()
        {
            {
                var parser = new TypeParserSbyte();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("-1"), -1);
                Assert.AreEqual(parser.Parse("100"), 100);
                Assert.AreEqual(parser.Parse("-100"), -100);
                Assert.AreEqual(parser.Parse(sbyte.MaxValue.ToString()), sbyte.MaxValue);
                Assert.AreEqual(parser.Parse(sbyte.MinValue.ToString()), sbyte.MinValue);
            }

            {
                var parser = new TypeParserInt16();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("-1"), -1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("-1337"), -1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse("-32000"), -32000);
                Assert.AreEqual(parser.Parse(short.MaxValue.ToString()), short.MaxValue);
                Assert.AreEqual(parser.Parse(short.MinValue.ToString()), short.MinValue);
            }

            {
                var parser = new TypeParserInt32();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("-1"), -1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("-1337"), -1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse("-32000"), -32000);
                Assert.AreEqual(parser.Parse("32000000"), 32000000);
                Assert.AreEqual(parser.Parse("-32000000"), -32000000);
                Assert.AreEqual(parser.Parse(int.MaxValue.ToString()), int.MaxValue);
                Assert.AreEqual(parser.Parse(int.MinValue.ToString()), int.MinValue);
            }

            {
                var parser = new TypeParserInt64();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("-1"), -1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("-1337"), -1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse("-32000"), -32000);
                Assert.AreEqual(parser.Parse("32000000"), 32000000);
                Assert.AreEqual(parser.Parse("-32000000"), -32000000);
                Assert.AreEqual(parser.Parse("3200000000000"), 3200000000000);
                Assert.AreEqual(parser.Parse("-3200000000000"), -3200000000000);
                Assert.AreEqual(parser.Parse(long.MaxValue.ToString()), long.MaxValue);
                Assert.AreEqual(parser.Parse(long.MinValue.ToString()), long.MinValue);
            }

            {
                var parser = new TypeParserByte();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("233"), 233);
                Assert.AreEqual(parser.Parse(byte.MaxValue.ToString()), byte.MaxValue);
                Assert.AreEqual(parser.Parse(byte.MinValue.ToString()), byte.MinValue);
            }

            {
                var parser = new TypeParserUint16();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse(ushort.MaxValue.ToString()), ushort.MaxValue);
                Assert.AreEqual(parser.Parse(ushort.MinValue.ToString()), ushort.MinValue);
            }

            {
                var parser = new TypeParserUint32();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse("32000000"), 32000000);
                Assert.AreEqual(parser.Parse(uint.MaxValue.ToString()), uint.MaxValue);
                Assert.AreEqual(parser.Parse(uint.MinValue.ToString()), uint.MinValue);
            }

            {
                var parser = new TypeParserUint64();
                Assert.AreEqual(parser.Parse("0"), 0);
                Assert.AreEqual(parser.Parse("1"), 1);
                Assert.AreEqual(parser.Parse("1337"), 1337);
                Assert.AreEqual(parser.Parse("32000"), 32000);
                Assert.AreEqual(parser.Parse("32000000"), 32000000);
                Assert.AreEqual(parser.Parse("3200000000000"), 3200000000000);
                Assert.AreEqual(parser.Parse(ulong.MaxValue.ToString()), ulong.MaxValue);
                Assert.AreEqual(parser.Parse(ulong.MinValue.ToString()), ulong.MinValue);
            }

        }

        [Test()]
        public void CanParse()
        {
            {
                var parser = new TypeParserSbyte();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("-1"));
                Assert.True(parser.CanParse("100"));
                Assert.True(parser.CanParse("-100"));
                Assert.True(parser.CanParse(sbyte.MaxValue.ToString()));
                Assert.True(parser.CanParse(sbyte.MinValue.ToString()));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserInt16();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("-1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("-1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse("-32000"));
                Assert.True(parser.CanParse(short.MaxValue.ToString()));
                Assert.True(parser.CanParse(short.MinValue.ToString()));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserInt32();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("-1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("-1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse("-32000"));
                Assert.True(parser.CanParse("32000000"));
                Assert.True(parser.CanParse("-32000000"));
                Assert.True(parser.CanParse(int.MaxValue.ToString()));
                Assert.True(parser.CanParse(int.MinValue.ToString()));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserInt64();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("-1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("-1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse("-32000"));
                Assert.True(parser.CanParse("32000000"));
                Assert.True(parser.CanParse("-32000000"));
                Assert.True(parser.CanParse("32000000000"));
                Assert.True(parser.CanParse("-32000000000"));
                Assert.True(parser.CanParse(long.MaxValue.ToString()));
                Assert.True(parser.CanParse(long.MinValue.ToString()));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserByte();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("100"));
                Assert.True(parser.CanParse(byte.MaxValue.ToString()));
                Assert.True(parser.CanParse(byte.MinValue.ToString()));
                Assert.False(parser.CanParse("-1"));
                Assert.False(parser.CanParse("-100"));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserUint16();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse(ushort.MaxValue.ToString()));
                Assert.True(parser.CanParse(ushort.MinValue.ToString()));
                Assert.False(parser.CanParse("-1"));
                Assert.False(parser.CanParse("-1337"));
                Assert.False(parser.CanParse("-32000"));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserUint32();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse("32000000"));
                Assert.True(parser.CanParse(uint.MaxValue.ToString()));
                Assert.True(parser.CanParse(uint.MinValue.ToString()));
                Assert.False(parser.CanParse("-1"));
                Assert.False(parser.CanParse("-1337"));
                Assert.False(parser.CanParse("-32000"));
                Assert.False(parser.CanParse("-32000000"));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

            {
                var parser = new TypeParserUint64();
                Assert.True(parser.CanParse("0"));
                Assert.True(parser.CanParse("1"));
                Assert.True(parser.CanParse("1337"));
                Assert.True(parser.CanParse("32000"));
                Assert.True(parser.CanParse("32000000"));
                Assert.True(parser.CanParse("32000000000"));
                Assert.True(parser.CanParse(ulong.MaxValue.ToString()));
                Assert.True(parser.CanParse(ulong.MinValue.ToString()));
                Assert.False(parser.CanParse("-1"));
                Assert.False(parser.CanParse("-1337"));
                Assert.False(parser.CanParse("-32000"));
                Assert.False(parser.CanParse("-32000000"));
                Assert.False(parser.CanParse("-32000000000"));
                Assert.False(parser.CanParse("x"));
                Assert.False(parser.CanParse("§"));
            }

        }
    }
}
