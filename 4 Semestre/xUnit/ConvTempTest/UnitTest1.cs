namespace ConvTempTest
{
    public class UnitTest1
    {
        [Fact]
        public void TesteConversor()
        {
            double x = 1;
            double temp = 33.8;
            var tempEmFahrenheit = ConvTemp.ConvTemp.ConverterCelsiusParaFahrenheit(x);

            Assert.Equal(tempEmFahrenheit, temp);
        }
    }
}