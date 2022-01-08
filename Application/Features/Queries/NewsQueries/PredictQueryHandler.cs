using Application.Features.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NewsQueries
{
    class PredictQueryHandler : IRequestHandler<PredictQuery, string>
    {
        public Task<string> Handle(PredictQuery request, CancellationToken cancellationToken)
        {
            //Load sample data
            var sampleData = new NewsModel.ModelInput()
            {
                Title = request.Title,
                Author = request.Author,
                Text = request.Text,
            };

            //Load model and predict output
            var result = NewsModel.Predict(sampleData);
            return Task.FromResult(result.Prediction == 1 ? "Fake" : "Real");
        }
    }
}
