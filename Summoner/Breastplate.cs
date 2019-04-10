namespace Trinity
{
    internal class Breastplate
    {
        internal class Breastplate : Equipement_Nospell
        {
            internal Breastplate(string name, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy) : base(name, max_life_point, max_mana_point, dodge_rate, accuracy)
            {
            }
        }
    }
}