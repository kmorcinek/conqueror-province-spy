namespace ProvinceSpy
{
    public interface INeededTurnsCalculator
    {
        int Calculate(ProvinceRevision revision, Buildings building);
    }
}