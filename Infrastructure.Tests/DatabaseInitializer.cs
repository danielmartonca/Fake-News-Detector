using System.Linq;
using Persistence.Context;
using Xunit;

namespace Infrastructure.Tests
{
    public class DatabaseInitializer
    {
        public static void Initialize(NewsContext context)
        {
            if (context.News.Any())
            {
                return;
            }
        }
    }
}
