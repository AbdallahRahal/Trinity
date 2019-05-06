using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Trinity
{
    public abstract class Equipement
    {
        readonly string _name;
        uint ratio;
        bool is_Paid;
        bool is_Equiped;
        string _path;

        Inventory inventory;

        public Equipement(string name, string path)
        {
            _name = name;
            _path = path;

            is_Paid = false;
            is_Equiped = false;

        }
        public bool Is_Equiped
        {
            get { return is_Equiped; }
            set { is_Equiped = value; }
        }

        public bool is_paid
        {
            get { return is_Paid; }
            set { is_Paid = value; }
        }

        public string Name
        {
            get { return _name; }
        }
        public string Path
        {
            get { return _path; }
        }
        public virtual Dictionary<string, string> Stats()
        {
            Dictionary<string, string> equip = new Dictionary<string, string>();
            equip.Add("Nom : ", _name);

            if (this is Equipement_Nospell)
            {
                Equipement_Nospell equip_nospell = (Equipement_Nospell)this;
                equip.Add("Vie : +", equip_nospell.Max_life_point.ToString());
                equip.Add("Mana : +", equip_nospell.Max_mana_point.ToString());
                equip.Add("Esquive : +", equip_nospell.Dodge_rate.ToString());
                equip.Add("Précision : +", equip_nospell.Accuracy.ToString());

                if(equip_nospell is Hat) equip.Add("Type : ", "Chapeau");
                if (equip_nospell is Breastplate) equip.Add("Type : ", "Plastron");
                if (equip_nospell is Leg) equip.Add("Type : ", "Jambières");
                if (equip_nospell is Boots) equip.Add("Type : ", "Bottes");
                
            }
            if (this is Weapon)
            {
                Weapon weapon = (Weapon)this;
                equip.Add("Vie : +", weapon.Power.ToString());
                equip.Add("Type : ", "Arme");
            }



            return equip;
        }

    }
}
