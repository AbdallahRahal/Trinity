using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Trinity
{
    public abstract class Equipement
    {
        readonly string _name;
        uint _price;
        bool _is_Paid;
        bool _is_Equiped;
        string _path;

        public Equipement(string name, uint price, string path)
        {
            _name = name;
            _price = price;
            _path = path;

            _is_Paid = false;
            _is_Equiped = false;

        }
        public bool Is_Equiped
        {
            get { return _is_Equiped; }
            set { _is_Equiped = value; }
        }

        public bool is_paid
        {
            get { return _is_Paid; }
            set { _is_Paid = value; }
        }

        public string Name
        {
            get { return _name; }
        }
        public uint Price
        {
            get { return _price; }
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
                equip.Add("Initiative : +", equip_nospell.Lead.ToString());


                if (equip_nospell is Hat) equip.Add("Type : ", "Chapeau");
                if (equip_nospell is Breastplate) equip.Add("Type : ", "Plastron");
                if (equip_nospell is Leg) equip.Add("Type : ", "Jambières");
                if (equip_nospell is Boots) equip.Add("Type : ", "Bottes");
                
            }else  if (this is Weapon)
            {
                Weapon weapon = (Weapon)this;
                equip.Add("Pouvoir : +", weapon.Power.ToString());
                equip.Add("Type : ", "Arme");
            }


            equip.Add("Prix : ", this.Price.ToString());
            if (this is Gem)
            {
                Gem gem = (Gem)this; equip.Add("Type : ", "Sort");
                equip.Add("Pouvoir : ", gem.desc());

            }
            return equip;
        }
        
    }
}
