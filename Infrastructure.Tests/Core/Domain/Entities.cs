using System;
using Xunit;
using Domain.Entities;

namespace Infrastructure.Tests.Core.Domain
{
    public class Entities
    {
        [Fact]
        public void News()
        {
            News n = new("Title", "Text", "Author", DateTime.Now);
            Assert.Equal("Title", n.Title);
            Assert.Equal("Text", n.Text);
            Assert.Equal("Author", n.Author);
        }

        [Fact]
        public void UrlLink()
        {
            String str = "https://www.digi24.ro/stiri/externe/rusia/video-aterizare-cu-emotii-in-rusia-o-aeronava-a-iesit-de-pe-pista-din-cauza-ghetii-1798273";
            UrlLink link = new(str);
            Assert.Equal(link.InputUrl, str);
        }


    }
}
