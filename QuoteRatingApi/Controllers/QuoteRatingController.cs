using Microsoft.AspNetCore.Mvc;
using QuoteRatingApi.Service;
using QuoteRatingApi.Service.DTOs;
using System;

namespace QuoteRatingApi.QuoteRatingApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public sealed class QuoteRatingController : ControllerBase
    {
        private readonly IQuoteRatingService _quoteRatingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteRatingController"/> class.
        /// </summary>
        public QuoteRatingController(IQuoteRatingService quoteRatingService)
        {
            _quoteRatingService = quoteRatingService ?? throw new ArgumentNullException(nameof(quoteRatingService));
        }

        // POST api/QuoteRating
        [HttpPost]
        [ProducesResponseType(typeof(PremiumQuoteDTO), 200)]
        [ProducesResponseType(400)]
        public ActionResult<PremiumQuoteDTO> GeneratePremiumQuote([FromBody] PremiumQuoteRequestDTO requestDTO)
        {
            return _quoteRatingService.ProcessPremiumQuoteRequest(requestDTO);
        }
    }
}
