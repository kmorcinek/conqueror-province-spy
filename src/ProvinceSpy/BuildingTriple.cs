namespace ProvinceSpy
{
    public class BuildingTriple
    {
        public readonly int Power;
        public readonly CultureLevel Culture;
        public readonly Buildings Building;

        public BuildingTriple(int power, CultureLevel culture, Buildings building)
        {
            this.Power = power;
            this.Culture = culture;
            this.Building = building;
        }

        protected bool Equals(BuildingTriple other)
        {
            return Power == other.Power && Culture == other.Culture && Building == other.Building;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BuildingTriple) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Power;
                hashCode = (hashCode*397) ^ (int) Culture;
                hashCode = (hashCode*397) ^ (int) Building;
                return hashCode;
            }
        }

        public BuildingTriple(BuildingStruct buildingStruct)
        {
            Power = buildingStruct.Power;
            Culture = buildingStruct.Culture;
            Building = buildingStruct.Building;
        }
    }
}