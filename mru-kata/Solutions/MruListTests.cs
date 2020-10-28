using System;
using Xunit;

namespace MruKata.Solutions
{
    public class MruListTests
    {
        [Fact]
        public void trackOneFile()
        {
            var list = new MruList(100);
            list.Track("foo");
            var result = list.Tracked();
            Assert.Equal(new[] {"foo"}, result);
        }

        [Fact]
        public void trackNoFiles()
        {
            var list = new MruList(100);
            var result = list.Tracked();
            Assert.Empty(result);
        }

        [Fact]
        public void trackManyFiles()
        {
            var list = new MruList(100);
            list.Track("foo");
            list.Track("bar");
            list.Track("baz");
            var result = list.Tracked();
            Assert.Equal(new[] {"baz", "bar", "foo"}, result);
        }

        [Fact]
        public void trackTooManyFiles()
        {
            var list = new MruList(2);
            list.Track("foo1");
            list.Track("foo2");
            list.Track("foo3");
            var result = list.Tracked();
            Assert.Equal(new[] {"foo3", "foo2"}, result);
        }

        [Fact]
        public void trackDuplicateFiles()
        {
            var list = new MruList(100);
            list.Track("foo1");
            list.Track("foo2");
            list.Track("foo1");
            var result = list.Tracked();
            Assert.Equal(new[] {"foo1", "foo2"}, result);
        }

        [Fact]
        public void trackNull()
        {
            var list = new MruList(100);
            Assert.Throws<ArgumentNullException>(() => list.Track(null));
        }
    }
}
