using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trinity
{
    public class Store
    {
        Dictionary<string, Equipement> _equipements;
        Tower _context;
        List<Equipement> _all_equip;
        List<Equipement> _available_equip;

        public Store(Tower context)
        {
            _equipements = context.Equipement_Collection.Equipement_Dictionnary;
            _context = context;
        }

        public void available()
        {
            int maxItems = 0;
            foreach (Equipement item in _equipements.Values.ToList())
            {
                if (!item.is_paid) {
                    maxItems++;
                }
            }
            maxItems = Math.Min(maxItems, 9);
            var tmp = new Dictionary<string, Equipement>();
            Random rand = new Random();

            var tab = _equipements.ToList();
            while (tmp.Count < maxItems)
            {
                if (tab.Count > 0)
                {
                    int r = rand.Next(tab.Count);
                    var pairEquipTmp = tab[r];
                    if (!tmp.ContainsKey(pairEquipTmp.Key) && !pairEquipTmp.Value.is_paid )
                    {
                        tmp.Add(pairEquipTmp.Key, pairEquipTmp.Value);
                    }
                }
            }
            _available_equip = tmp.Values.ToList();
        }

        public void  Buy_Equip(Equipement equip)
        {
            if (equip.is_paid == false)
            {
                if (_context.Summoner.Money >= equip.Price)
                {
                    _context.Summoner.Money -= equip.Price;
                    equip.is_paid = true;
                    _available_equip.Remove(equip);
                    _context.Summoner.Inventory.AddEquip(equip);
                }
                else
                if (_context.Summoner.Money < equip.Price)
                {
                    throw new ArgumentException("you aren't too much money for buy this equipement .", nameof(equip.Name));
                }
            }
        }

        public Tower Tower { get { return _context; } }

        public List<Equipement> available_Equipement
        {
            get { return _available_equip; }
        }
    }

}
