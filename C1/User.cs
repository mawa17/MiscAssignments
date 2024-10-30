using System.Text.Json;

namespace C1
{
    public sealed record User(string Name, string? Number, string? Email);
    public static class UserRepository
    {
        private static HashSet<User> _users = new();
        public static IReadOnlyCollection<User> Users => _users;
        private const string FilePath = "C:\\Users\\marcu\\Desktop\\H1\\Programming\\MiscAssignments\\users.json";
        public static async Task LoadUsers()
        {
            if (!File.Exists(FilePath)) using (FileStream fs = File.Create(FilePath)) fs.Dispose(); 
            using var streamReader = new StreamReader(FilePath);
            var jsonContent = await streamReader.ReadToEndAsync();
            try
            {
                _users = JsonSerializer.Deserialize<HashSet<User>>(jsonContent) ?? new();
            } catch { InitUsers(); }
        }
        public static async Task SaveUsers()
        {
            using var streamWriter = new StreamWriter(FilePath, false);
            var jsonContent = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
            await streamWriter.WriteAsync(jsonContent);
        }
        public static void InitUsers() /*Credits to ChatGPT for dummy data*/
        {
            _users.Add(new("Alejandro Anderson", "67843661", "jacob12@gmail.com"));
            _users.Add(new("Regina Gray", "59042531", "mistyjones@oconnor-everett.com"));
            _users.Add(new("Larry Gates", "47209954", "lauradixon@sanchez.biz"));
            _users.Add(new("Jeffrey Henry", "26834101", "cray@yahoo.com"));
            _users.Add(new("Andrew Rios", "51136546", "joshua89@west.org"));
            _users.Add(new("Carla James", "86902107", "coxsteven@perez.com"));
            _users.Add(new("Vincent Cruz DDS", "24431270", "robersonmatthew@colon-murillo.net"));
            _users.Add(new("Kelly Baker", "39353201", "burkematthew@yahoo.com"));
            _users.Add(new("Melissa Williams", "21384961", "ystone@hotmail.com"));
            _users.Add(new("Rhonda Chung", "94864511", "paulbell@cruz.com"));
            _users.Add(new("Steven Bennett", "48232028", "guzmanstacey@huang-brown.com"));
            _users.Add(new("Tammy Herrera", "27034872", "kenneth61@long-carter.net"));
            _users.Add(new("Jennifer Silva", "19290337", "tmoody@hotmail.com"));
            _users.Add(new("Bobby Bell", "58991964", "jayerickson@mccall.biz"));
            _users.Add(new("Mr. Michael Williams", "88873560", "williscarol@taylor.com"));
            _users.Add(new("Mikayla Reynolds", "94917567", "christian97@hunt.org"));
            _users.Add(new("Bryan Vega", "86803652", "jenniferle@potter.org"));
            _users.Add(new("Theresa Porter", "39836000", "kathy61@jones.com"));
            _users.Add(new("Sandy Garcia", "56169124", "vwilliams@parsons.com"));
            _users.Add(new("Spencer Lewis", "54160046", "jamesrobert@hotmail.com"));
            _users.Add(new("Richard Gilbert", "19352834", "htate@yahoo.com"));
            _users.Add(new("Brandon Marquez", "21404670", "icollins@foley-webb.biz"));
            _users.Add(new("Bradley Bailey", "61069734", "coreysmith@hotmail.com"));
            _users.Add(new("Elizabeth Morris", "16833289", "janicemiller@fleming.info"));
            _users.Add(new("Rebekah Avila", "47016055", "heathersullivan@haynes.com"));
            _users.Add(new("Jordan Scott", "90338472", "ggonzales@long.com"));
            _users.Add(new("Julie Evans", "58728687", "ashleycross@williams-ford.info"));
            _users.Add(new("Shawna Lewis", "52164913", "andrewssarah@gonzalez.org"));
            _users.Add(new("Tracy Carey", "30646007", "amandapearson@gmail.com"));
            _users.Add(new("Benjamin Jordan", "79257018", "john85@sparks-hunter.com"));
            _users.Add(new("Steven Henderson", "18210070", "cantrelldaniel@gmail.com"));
            _users.Add(new("Patrick Hartman", "36620398", "douglas79@yahoo.com"));
            _users.Add(new("Robert Gould", "68516793", "todd71@gmail.com"));
            _users.Add(new("Matthew Parsons", "79708195", "laraelizabeth@white-cole.org"));
            _users.Add(new("Rebecca Pennington", "28394279", "amybarnes@carney.com"));
            _users.Add(new("Julie Newton", "80522697", "cruzemily@gmail.com"));
            _users.Add(new("Joseph Freeman", "91829221", "knappsarah@yahoo.com"));
            _users.Add(new("Sarah Phillips", "71577951", "troypotter@hotmail.com"));
            _users.Add(new("Joseph Cox", "87077262", "gthompson@yahoo.com"));
            _users.Add(new("Cassandra James", "57031457", "daniellemiller@richardson.com"));
            _users.Add(new("Michael Nelson", "39020959", "bnichols@gmail.com"));
            _users.Add(new("George Pennington DDS", "44659597", "simmonsgary@jones-mcbride.com"));
            _users.Add(new("Hunter Garcia", "63776859", "cfletcher@gmail.com"));
            _users.Add(new("Michelle Poole", "95493456", "kenneth75@torres.com"));
            _users.Add(new("Frank Pierce", "15791621", "roger34@gmail.com"));
            _users.Add(new("Sara Todd", "45857931", "paul82@berry.com"));
            _users.Add(new("Jane Vincent", "49847736", "stewartmary@richardson.info"));
            _users.Add(new("Cassandra Hernandez", "45176245", "angela07@hotmail.com"));
            _users.Add(new("Shawn Rosario", "44442138", "webbamanda@porter.net"));
            _users.Add(new("Jessica Evans", "77366114", "clarkdavid@hotmail.com"));
            _users.Add(new("Jordan Lee", "68317299", "susan04@hotmail.com"));
            _users.Add(new("Jose Fox", "75243574", "wendygallagher@jones-elliott.com"));
            _users.Add(new("David Jackson", "14435419", "travis45@schroeder-gallagher.com"));
            _users.Add(new("Donald Smith", "76855186", "cummingsmark@osborn.biz"));
            _users.Add(new("Autumn Holden", "91637385", "hallandrea@yahoo.com"));
            _users.Add(new("Miss Linda Morgan", "54451535", "allisonmorse@yahoo.com"));
            _users.Add(new("Randy Calhoun", "75231347", "muellererin@gmail.com"));
            _users.Add(new("Paul Simon", "69628984", "victoria92@hotmail.com"));
            _users.Add(new("Jennifer Byrd", "14314274", "manningerika@mercado-henson.biz"));
            _users.Add(new("Anthony Jones", "76459801", "luismichael@hotmail.com"));
            _users.Add(new("Kevin Beasley", "71367494", "jbaker@thompson-figueroa.com"));
            _users.Add(new("Carol Gomez", "90354712", "daniel49@hotmail.com"));
            _users.Add(new("Shari Bell", "50672006", "angela70@gmail.com"));
            _users.Add(new("Susan Parker", "99459669", "brianna40@cline.net"));
            _users.Add(new("Sarah Parker", "67074072", "annette71@glover.biz"));
            _users.Add(new("Jordan Graham", "86420180", "jenna20@mcdonald-roberts.org"));
            _users.Add(new("Mrs. Becky Cooper", "25375921", "gburns@gomez.net"));
            _users.Add(new("Jeremy Walker", "90979294", "xmoran@hotmail.com"));
            _users.Add(new("Manuel Fox", "45284721", "michelle92@graves-gonzalez.com"));
            _users.Add(new("Patrick Baker", "84053087", "kim37@yahoo.com"));
            _users.Add(new("Angela Jacobs", "49310119", "davisamanda@gmail.com"));
            _users.Add(new("Daniel Ibarra", "93491022", "gking@hotmail.com"));
            _users.Add(new("Mr. Timothy Lee II", "20547073", "asmith@hall.com"));
            _users.Add(new("Jennifer Pierce", "17880450", "nthompson@russo.com"));
            _users.Add(new("Geoffrey Washington", "99422613", "conraddavid@yahoo.com"));
            _users.Add(new("Gabrielle Norris", "72870193", "john33@robles.com"));
            _users.Add(new("Lindsey Diaz", "41946328", "vclayton@hotmail.com"));
            _users.Add(new("Amanda Ramos", "80781240", "kimberlysmith@gmail.com"));
            _users.Add(new("Nicole Shelton", "55050216", "tramos@bowman.com"));
            _users.Add(new("Sharon Vaughn", "92935297", "etaylor@holland.info"));
            _users.Add(new("James Smith", "14831804", "ruizashley@gmail.com"));
            _users.Add(new("Wesley Carlson", "16078335", "wilcoxbrendan@carter.com"));
            _users.Add(new("Juan Brooks", "87389461", "boothlinda@yahoo.com"));
            _users.Add(new("Shawn Harris", "29308524", "celliott@baldwin.biz"));
            _users.Add(new("Kristy Gomez", "77343015", "angela91@coleman.com"));
            _users.Add(new("Peter Wood", "75792577", "elizabeth79@warren.org"));
            _users.Add(new("James Edwards", "59577067", "tiffany48@saunders.biz"));
            _users.Add(new("Kenneth Reese", "56832460", "kmoreno@yahoo.com"));
            _users.Add(new("Martha Owen", "80080568", "richard76@davis.org"));
            _users.Add(new("Jill Kelly", "78566526", "jamesdavis@mathis.info"));
            _users.Add(new("Joshua Johnson", "83013237", "joshuabrady@hotmail.com"));
            _users.Add(new("Kelli Harrison", "91405287", "mhenderson@walker.com"));
            _users.Add(new("Jonathan Graham", "63426721", "jessica18@clark.net"));
            _users.Add(new("Justin Howell", "62892613", "haysjessica@hotmail.com"));
            _users.Add(new("Evan Johnson", "82045881", "vhall@jones.com"));
            _users.Add(new("Cassidy Barton", "53233309", "qgomez@yahoo.com"));
            _users.Add(new("Zachary Larson", "32528124", "dennis66@harper.com"));
            _users.Add(new("Trevor Kelley", "94859949", "acook@graham-quinn.org"));
            _users.Add(new("Nicole Lewis", "40597445", "fmiller@gmail.com"));
            _users.Add(new("Jeffrey Phillips", "33776917", "mmendez@hunter.com"));
        }

        public static void AddUser(in User user) => _users.Add(user);
        public static void RemoveUser(in User user) => _users.Remove(user);
        public static bool EditUser(in User user, in User newUser, bool exact = false)
        {
            var usr = GetUser(user, exact);
            if (usr is null) return false;
            RemoveUser(usr);
            AddUser(newUser);
            return true;
        }
        public static IEnumerable<User> GetUsers(this IEnumerable<User> users, int quantity, int offset) => users.Skip(offset).Take(quantity);
        public static IEnumerable<User> SortUsers<T>(this IEnumerable<User> users, Func<User, T> func) => users.OrderBy(func);
        public static User? GetUser(User user, bool exact = false)
        {
            return _users.FirstOrDefault(usr =>
                exact ? usr.Equals(user) :
                (user.Name != null && usr.Name.Contains(user.Name, StringComparison.OrdinalIgnoreCase)) ||
                (user.Email != null && usr.Email.Contains(user.Email, StringComparison.OrdinalIgnoreCase)) ||
                (user.Number != null && usr.Number.Contains(user.Number))
            );
        }
        public static IEnumerable<User> SearchUsers(User user, bool exact = false)
        {
            return _users.Where(usr =>
                exact ? usr.Equals(user) :
                (user.Name != null && usr.Name.Contains(user.Name, StringComparison.OrdinalIgnoreCase)) ||
                (user.Email != null && usr.Email.Contains(user.Email, StringComparison.OrdinalIgnoreCase)) ||
                (user.Number != null && usr.Number.Contains(user.Number))
            );
        }

    }
}