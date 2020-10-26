using Xunit;
using static BookStore.BookBuilder;
using static BookStore.BasketBuilder;

namespace BookStore
{
    public class BasketTests
    {
        [Fact]
        public void return_total_price_of_zero_when_empty()
        {
            Assert.Equal(0m, EmptyBasket().FullPrice());
        }

        [Fact]
        public void return_zero_discount_when_empty()
        {
            Assert.Equal(0m, EmptyBasket().PriceWithDiscount());
        }

        [Fact]
        public void give_no_discount_when_book_is_not_eligible_for_a_discount()
        {
            var basket = aBasket()
                .With(CookingBook().Costing(10.00m))
                .Build();

            Assert.Equal(10m, basket.PriceWithDiscount());
            Assert.Equal(10m, basket.FullPrice());
        }

        [Fact]
        public void calculate_the_total_price_with_no_discount_when_containing_multiple_books()
        {
            var basket = aBasket()
                .With(
                    CookingBook().Costing(10.0m),
                    ITBook().Costing(30.0m),
                    ITBook().Costing(20.0m),
                    TravelBook().Costing(20.0m))
                .Build();

            Assert.Equal(80m, basket.FullPrice());
        }

        [Fact]
        public void give_30_percent_discount_for_IT_books_when_containing_more_than_two_of_them()
        {
            var basket = aBasket()
                .With(
                    ITBook().Costing(30.0m),
                    ITBook().Costing(10.0m),
                    ITBook().Costing(20.0m))
                .Build();

            Assert.Equal(42m, basket.PriceWithDiscount());
        }

        [Fact]
        public void give_10_percent_discount_for_IT_books_when_containing_on_of_them()
        {
            var basket = aBasket()
                .With(
                    ITBook().Costing(10.0m))
                .Build();

            Assert.Equal(9m, basket.PriceWithDiscount());
        }

        [Fact]
        public void give_10_percent_discount_for_IT_books_when_containing_two_of_them()
        {
            var basket = aBasket()
                .With(
                    ITBook().Costing(30.0m),
                    ITBook().Costing(10.0m))
                .Build();

            Assert.Equal(36m, basket.PriceWithDiscount());
        }

        [Fact]
        public void not_give_discounts_for_Travel_books_when_containing_less_than_four_of_them()
        {
            var basket = aBasket()
                .With(
                    TravelBook().Costing(30.0m),
                    TravelBook().Costing(10.0m),
                    TravelBook().Costing(20.0m))
                .Build();

            Assert.Equal(60m, basket.PriceWithDiscount());
        }

        [Fact]
        public void give_40_percent_discount_for_Travel_books_when_containing_more_than_three_of_them()
        {
            var basket = aBasket()
                .With(
                    TravelBook().Costing(30.0m),
                    TravelBook().Costing(10.0m),
                    TravelBook().Costing(20.0m),
                    TravelBook().Costing(10.0m))
                .Build();

            Assert.Equal(42m, basket.PriceWithDiscount());
        }

        [Fact]
        public void combine_10_percent_discount_for_1_IT_book_and_40_percent_discount_for_4_Travel_books()
        {
            var basket = aBasket()
                .With(
                    ITBook().Costing(10.0m),
                    TravelBook().Costing(30.0m),
                    TravelBook().Costing(10.0m),
                    TravelBook().Costing(20.0m),
                    TravelBook().Costing(10.0m))
                .Build();

            Assert.Equal(51m, basket.PriceWithDiscount());
        }
    }
}
