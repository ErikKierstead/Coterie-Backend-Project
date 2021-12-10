using QuoteRatingApi.Common.Enums;
using QuoteRatingApi.QuoteRatingEngine.Premium;
using System;
using System.Collections.Generic;

namespace QuoteRatingApi.QuoteRatingEngine
{
    ///<inheritdoc/>
    public sealed class QuoteRatingEngine : IQuoteRatingEngine
    {
        #region Fields

        // Algorithm values hardcoded for demo purposes. Should be provided by another mechanism (repository, API call, DB call, etc)
        private readonly Dictionary<StatePostalCode, decimal> _stateToStateFactorMap = new Dictionary<StatePostalCode, decimal>()
        {
            { StatePostalCode.FL, 1.2m },
            { StatePostalCode.OH, 1m },
            { StatePostalCode.TX, 0.943m }
        };

        private readonly Dictionary<BusinessType, decimal> _businessToBusinessFactorMap = new Dictionary<BusinessType, decimal>()
        {
            { BusinessType.Architect, 1m },
            { BusinessType.Plumber, 0.5m },
            { BusinessType.Programmer, 1.25m }
        };

        private static readonly decimal _basePremiumDivisor = 1000m;
        private static readonly int _hazardFactor = 4;

        private readonly IPremiumQuoteCalculator _premiumCalculator;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteRatingEngine"/> class.
        /// </summary>
        public QuoteRatingEngine(IPremiumQuoteCalculator quoteRatingCalculator)
        {
            _premiumCalculator = quoteRatingCalculator ?? throw new ArgumentNullException(nameof(quoteRatingCalculator));
        }

        #endregion

        #region Public Methods

        ///<inheritdoc/>
        public PremiumQuote CalculatePremiumQuote(PremiumQuoteRequest ratingRequest)
        {
            if (ratingRequest == null)
            {
                throw new ArgumentNullException(nameof(ratingRequest));
            }

            // Temporary validation and could be alleviated by another design approach:
            if (!_stateToStateFactorMap.ContainsKey(ratingRequest.State) || !_businessToBusinessFactorMap.ContainsKey(ratingRequest.Business))
            {
                throw new ArgumentException(nameof(ratingRequest));
            }

            decimal stateFactor = _stateToStateFactorMap[ratingRequest.State];
            decimal businessFactor = _businessToBusinessFactorMap[ratingRequest.Business];

            decimal premium = _premiumCalculator.CalculatePremiumQuote(ratingRequest.Revenue, stateFactor, businessFactor, _basePremiumDivisor, _hazardFactor);
            return new PremiumQuote(premium);
        }

        #endregion
    }
}
