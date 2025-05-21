using System;
using System.Collections.Generic;
using System.Linq;
using Enemies;
using Intelligence;
using IDF.StrikeUnits;
using Core;

namespace Services
{
    public class StrikeService
    {
        private readonly List<IStrikeUnit> _strikeUnits;
        private readonly List<IntelligenceMessage> _intelMessages;

        public StrikeService(List<IStrikeUnit> strikeUnits, List<IntelligenceMessage> intelMessages)
        {
            _strikeUnits = strikeUnits;
            _intelMessages = intelMessages;
        }

        public Terrorist? GetMostDangerousTerrorist(List<Terrorist> terrorists)
        {
            Terrorist? top = null;
            int topScore = -1;

            foreach (var terrorist in terrorists)
            {
                int weaponScore = terrorist.Weapons.Sum(w =>
                    w == WeaponType.Knife ? 1 :
                    w == WeaponType.Gun ? 2 :
                    3 // M16 or AK47
                );

                int score = terrorist.Rank * weaponScore;

                if (score > topScore)
                {
                    topScore = score;
                    top = terrorist;
                }
            }

            return top;
        }

        public IStrikeUnit? RecommendStrikeUnit(TargetType targetType)
        {
            foreach (var unit in _strikeUnits)
            {
                if (unit.CanStrike(targetType))
                {
                    return unit;
                }
            }
            return null;
        }

        public IntelligenceMessage? GetLatestIntel(Terrorist terrorist)
        {
            return _intelMessages
                .Where(m => m.TerroristTarget == terrorist)
                .OrderByDescending(m => m.Timestamp)
                .FirstOrDefault();
        }
    }
}