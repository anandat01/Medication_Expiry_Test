namespace EngineerTest;

public class Pharmacy : IPharmacy
{
    private readonly IDrug[] _drugs;

    public Pharmacy(IEnumerable<IDrug> drugs)
    {
        _drugs = drugs.ToArray();
    }

    public IEnumerable<IDrug> UpdateBenefitValue()
    {
        //defining maximum and minimum benefits value
        int MaxBenefit = 50;
        int MinBenefit = 0;

        //looping through all drug to implement specific conditions
        for (var i = 0; i < _drugs.Length; i++)
        {
            switch (_drugs[i].Name)
            {
                case "Magic Pill":
                    _drugs[i].Benefit = _drugs[i].Benefit;
                    _drugs[i].ExpiresIn = _drugs[i].ExpiresIn;
                    break;

                case "Herbal Tea":
                    if (_drugs[i].ExpiresIn > 0)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit + 1) <= MaxBenefit ? (_drugs[i].Benefit + 1) : MaxBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit + 2) <= MaxBenefit ? (_drugs[i].Benefit + 2) : MaxBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    break;

                case "Fervex":
                    if (_drugs[i].ExpiresIn > 10)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit + 1) <= MaxBenefit ? (_drugs[i].Benefit + 1) : MaxBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else if (_drugs[i].ExpiresIn <= 10 && _drugs[i].ExpiresIn > 5)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit + 2) <= MaxBenefit ? (_drugs[i].Benefit + 2) : MaxBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else if (_drugs[i].ExpiresIn <= 5 && _drugs[i].ExpiresIn > 0)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit + 3) <= MaxBenefit ? (_drugs[i].Benefit + 3) : MaxBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else
                    {
                        _drugs[i].Benefit = 0;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    break;

                case "Dafalgan":
                    if (_drugs[i].ExpiresIn > 0)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit - 2) > MinBenefit ? (_drugs[i].Benefit - 2) : MinBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit - 4) > MinBenefit ? (_drugs[i].Benefit - 4) : MinBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    break;

                default:
                    if (_drugs[i].ExpiresIn > 0)
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit - 1) > MinBenefit ? (_drugs[i].Benefit - 1) : MinBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    else
                    {
                        _drugs[i].Benefit = (_drugs[i].Benefit - 2) > MinBenefit ? (_drugs[i].Benefit - 2) : MinBenefit;
                        _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
                    }
                    break;
            }
        }
        return _drugs;
    }
}