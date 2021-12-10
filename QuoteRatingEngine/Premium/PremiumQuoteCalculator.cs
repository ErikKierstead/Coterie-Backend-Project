using System;

namespace QuoteRatingApi.QuoteRatingEngine.Premium
{
    ///  <inheritdoc/>
    public sealed class PremiumQuoteCalculator : IPremiumQuoteCalculator
    {
        ///  <inheritdoc/>
        public decimal CalculatePremiumQuote(decimal revenue, decimal stateFactor, decimal businessFactor, decimal basePremiumDivisor, int hazardFactor)
        {
            decimal basePremium = Math.Ceiling(revenue / basePremiumDivisor);
            return Decimal.Round(stateFactor * businessFactor * basePremium * (decimal)hazardFactor, 2);
        }
    }
}
