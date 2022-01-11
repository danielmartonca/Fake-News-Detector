using System;
using Xunit;
using Application.Utilities.Scrapper;
using Domain.Entities;

namespace Infrastructure.Tests.Core
{
    public class Scrapper
    {
        [Fact]
        public void TitleGetNewsFromUrl()
        {
            String str = "https://www.digi24.ro/stiri/externe/rusia/video-aterizare-cu-emotii-in-rusia-o-aeronava-a-iesit-de-pe-pista-din-cauza-ghetii-1798273";
            News n = WebScrapper.GetNewsFromUrl(str);
            Assert.Equal(" VIDEO. Aterizare cu emoții în Rusia. O aeronavă a ieșit de pe pistă din cauza gheții ", n.Title);
        }

        [Fact]
        public void AuthorGetNewsFromUrl()
        {
            String str = "https://www.digi24.ro/stiri/externe/rusia/video-aterizare-cu-emotii-in-rusia-o-aeronava-a-iesit-de-pe-pista-din-cauza-ghetii-1798273";
            News n = WebScrapper.GetNewsFromUrl(str);
            Assert.Equal("Unknown", n.Author);
        }

        [Fact]
        public void TextGetNewsFromUrl()
        {
            String str = "https://www.digi24.ro/stiri/externe/rusia/video-aterizare-cu-emotii-in-rusia-o-aeronava-a-iesit-de-pe-pista-din-cauza-ghetii-1798273";
            News n = WebScrapper.GetNewsFromUrl(str);
            Assert.Equal("Aterizare cu peripeții pentru câteva zeci de oameni, al căror avion a ieșit de pe pistă în momentul aterizării.  S-a întâmplat într-un oraş din vestul Rusiei, situat la 570 de kilometri de Moscova. Aeronava a ieşit în decor şi s-a oprit după 40 de metri. În ciuda aterizării cu probleme, nimeni nu a fost rănit şi toată lumea a fost evacuată în siguranţă.  O comisie de anchetă urmează să stabilească acum motivul pentru care a apărut problema. Din primele date se pare că aparatul de zbor a derapat din cauza zăpezii și gheții de pe pistă.  Editor :  Liviu Cojan   ", n.Text);
        }
    }
    }
