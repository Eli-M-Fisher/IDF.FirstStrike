

namespace IDF.StrikeUnits
{
    public enum TargetType
    {
        People,
        Vehicles,
        Buildings,
        OpenArea
    }

    public interface IStrikeUnit
    {
        string Name { get; }
        int AmmoCount { get; }
        int FuelLevel { get; }
        TargetType EffectiveAgainst { get; }

        bool CanStrike(TargetType target);
        void ConsumeAmmo();
        void ConsumeFuel();
        string ReportStatus();
    }
}