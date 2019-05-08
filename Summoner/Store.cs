using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trinity
{
    public class Store
    {
        Dictionary<string, Equipement> _equipements;
        Inventory _inventory;
        Tower _context;
        List<Equipement> _all_equip;
        List<Equipement> _aviable_equip;

        public Store(Tower context)
        {
            _equipements = context.Equipement_Collection.Equipement_Dictionnary;
        }

        public List<Equipement> Aviable()
        {
            int maxItems = 5;
            var tmp = new Dictionary<string, Equipement>();
            Random rand = new Random();

            var tab = _equipements.ToList();
            while (tmp.Count < maxItems)
            {
                int r = rand.Next(maxItems);
                var pairEquipTmp = tab[r];
                if (!tmp.ContainsKey(pairEquipTmp.Key))
                {
                    tmp.Add(pairEquipTmp.Key, pairEquipTmp.Value);
                }
            }
            return tmp.Values.ToList();
        }

        public bool Buy_Equip(Equipement equip)
        {
            if(_aviable_equip.Contains(equip)) throw new ArgumentException("An equipements  with this name already exists.", nameof(equip.Name));
            if (equip.is_paid == false)
            {
                if (_context.Summoner.Money >= equip.Price)
                {
                    _context.Summoner.Money -= equip.Price;
                    equip.is_paid = true;
                    _aviable_equip.Remove(equip);
                    _inventory.AddEquip(equip);
                }
                else
                if (_context.Summoner.Money < equip.Price)
                {
                    throw new ArgumentException("you aren't too much money for buy this equipement .", nameof(equip.Name));
                }
                return true;
            }
            else
            {
                throw new ArgumentException("An equipement is already buy.", nameof(equip.Name));
            }
        }

        public Tower Tower { get { return _context; } }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }

}
