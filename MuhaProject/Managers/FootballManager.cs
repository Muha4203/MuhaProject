using FootballPlayers;

namespace MuhaProject.Managers
{
    public class FootballManager
    {
        private static int _nextID = 1;
        private static readonly List<FootballPlayer> _data = new List<FootballPlayer>()
        {
            new FootballPlayer(){Id = _nextID++, ShirtNo=12, Age=10, Name= "Leo" },
            new FootballPlayer(){Id = _nextID++, ShirtNo= 11, Age=12, Name= "Cavani" },
            new FootballPlayer(){Id = _nextID++, ShirtNo=10, Age=30, Name= "Zlatan" }
        };
        public IEnumerable<FootballPlayer> GetAll(string? nameFilter)
        {
            List<FootballPlayer> result = new List<FootballPlayer>(_data);
            if (nameFilter != null)
            {
                result = result.FindAll(FootballPlayers => FootballPlayers.Name.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase));
            }

            return result;
        }
            public FootballPlayer? GetById(int Id)
            {
                return _data.Find(FootballPlayers => FootballPlayers.Id == Id);
            }

            public FootballPlayer Add(FootballPlayer newFootballPlayer)
            {
                newFootballPlayer.Validate();
                newFootballPlayer.Id = _nextID++;
                _data.Add(newFootballPlayer);
                return newFootballPlayer;
            }
             public FootballPlayer? Delete(int Id)
            {
            FootballPlayer? foundFootballPlayer = GetById(Id);
            if (foundFootballPlayer == null) return null;
            _data.Remove(foundFootballPlayer);
            return foundFootballPlayer;
             }

            public FootballPlayer? Update(int id, FootballPlayer updates)
          {
            FootballPlayer? FootballPlayers = GetById(id);
            if (FootballPlayers == null) return null;
            FootballPlayers.ShirtNo = updates.ShirtNo;
            FootballPlayers.Age = updates.Age;
            FootballPlayers.Name = updates.Name;
            return FootballPlayers;
           }


    }
    }

