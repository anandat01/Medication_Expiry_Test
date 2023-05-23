using EngineerTest;
using Xunit;

namespace EngineerTestTest;

public class TestPharmacy
{
    [Fact]
    public void Test_DrugBenefitExpiryValue()
    {
        Assert.Equal(new Drug[] { new Drug("paracetamole", 10, 20) },
            new Pharmacy(new Drug[] { new Drug("paracetamole", 11, 21) }).UpdateBenefitValue());
    }
}