using QuoteRatingApi.QuoteRatingEngine;
using QuoteRatingApi.QuoteRatingEngine.Premium;
using QuoteRatingApi.Service.DTOs;
using System;

namespace QuoteRatingApi.Service
{
    ///<inheritdoc/>
    public sealed class QuoteRatingService : IQuoteRatingService
    {
        private readonly IQuoteRatingEngine _quoteRatingEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteRatingService"/> class.
        /// </summary>
        public QuoteRatingService(IQuoteRatingEngine quoteRatingEngine)
        {
            _quoteRatingEngine = quoteRatingEngine ?? throw new ArgumentNullException(nameof(quoteRatingEngine));
        }

        ///<inheritdoc/>
        public PremiumQuoteDTO ProcessPremiumQuoteRequest(PremiumQuoteRequestDTO requestDTO)
        {
            if (requestDTO == null)
            {
                throw new ArgumentNullException(nameof(requestDTO));
            }

            PremiumQuoteRequest ratingRequest = new PremiumQuoteRequest()
            {
                Revenue = requestDTO.Revenue,
                State = requestDTO.State,
                Business = requestDTO.Business
            };

            PremiumQuote result = _quoteRatingEngine.CalculatePremiumQuote(ratingRequest);
            return new PremiumQuoteDTO(result.Premium);
        }
    }
}
