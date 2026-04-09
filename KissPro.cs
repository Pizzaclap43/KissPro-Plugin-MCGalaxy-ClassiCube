using System;
using MCGalaxy;

namespace MCGalaxy {
    public class KissPro : Plugin { 
        public override string name { get { return "KissPro"; } }
        public override string MCGalaxy_Version { get { return "1.5.9.3"; } }
        public override string creator { get { return "jose_120 & AndresDMC"; } }

        public override void Load(bool startup) {
            Command.Register(new CmdKiss());
        }

        public override void Unload(bool shutdown) {
            Command.Unregister(Command.Find("kiss"));
        }
    }

    public class CmdKiss : Command {
        public override string name { get { return "kiss"; } }
        public override string type { get { return "other"; } }

        public override void Use(Player p, string message) {
            if (string.IsNullOrEmpty(message)) {
                p.Message("Modo de uso: /kiss [nombre]");
                return;
            }

            Player target = null;
            Player[] online = PlayerInfo.Online.Items;

            foreach (Player pl in online) {
                if (pl.name.ToLower() == message.ToLower()) {
                    target = pl;
                    break;
                }
            }

            if (target == null) {
                p.Message("Ese jugador no esta conectado.");
                return;
            }


            p.level.Message("&d♥ &f" + p.name + " &7le dio un beso a &f" + target.name + " &d♥");
        }

        public override void Help(Player p) {
            p.Message("/kiss [nombre] - Envía un beso.");
        }
    }
}