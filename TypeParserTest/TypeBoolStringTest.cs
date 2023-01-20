﻿using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using ThrowException.CSharpLibs.TypeParserLib;

namespace ThrowException.CSharpLibs.TypeParserTest
{
    [TestFixture()]
    public class TypeBoolStringTest
    {
        [Test()]
        public void TryParse()
        {
            Assert.True(TypeParsers.TryParse("hello", out string v1));
            Assert.AreEqual(v1, "hello");
        }

        [Test()]
        public void Parse()
        {
            var parser = new TypeParserString();
            Assert.AreEqual(parser.Parse("hello"), "hello");
        }

        [Test()]
        public void CanParse()
        {
            var parser = new TypeParserString();
            Assert.True(parser.CanParse("hello"));
        }
    }
}
