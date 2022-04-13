using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xivapi
{
    // In .NET, we call this "a poor man's enum"
    public interface IRegion
    {
        public string Value { get; }
    }

    public class DataCentre : IRegion
    {
        private DataCentre(string name) { Value = name; }
        public string Value { get; private set; }

        public static DataCentre Elemental { get { return new DataCentre("_dc_elemental"); } }
        public static DataCentre Gaia { get { return new DataCentre("_dc_gaia"); } }
        public static DataCentre Mana { get { return new DataCentre("_dc_mana"); } }
        public static DataCentre Primal { get { return new DataCentre("_dc_primal"); } }
        public static DataCentre Aether { get { return new DataCentre("_dc_aether"); } }
        public static DataCentre Crystal { get { return new DataCentre("_dc_crystal"); } }
        public static DataCentre Chaos { get { return new DataCentre("_dc_chaos"); } }
        public static DataCentre Light { get { return new DataCentre("_dc_light"); } }
        public static DataCentre Materia { get { return new DataCentre("_dc_materia"); } }
    }

    public class ServerName : IRegion
    {
        private ServerName(string name) { Value = name; }
        public string Value { get; private set; }

        public static ServerName Adamantoise { get { return new ServerName("Adamantoise"); } }
        public static ServerName Aegis { get { return new ServerName("Aegis"); } }
        public static ServerName Alexander { get { return new ServerName("Alexander"); } }
        public static ServerName Anima { get { return new ServerName("Anima"); } }
        public static ServerName Asura { get { return new ServerName("Asura"); } }
        public static ServerName Atomos { get { return new ServerName("Atomos"); } }
        public static ServerName Bahamut { get { return new ServerName("Bahamut"); } }
        public static ServerName Balmung { get { return new ServerName("Balmung"); } }
        public static ServerName Behemoth { get { return new ServerName("Behemoth"); } }
        public static ServerName Belias { get { return new ServerName("Belias"); } }
        public static ServerName Brynhildr { get { return new ServerName("Brynhildr"); } }
        public static ServerName Cactuar { get { return new ServerName("Cactuar"); } }
        public static ServerName Carbuncle { get { return new ServerName("Carbuncle"); } }
        public static ServerName Cerberus { get { return new ServerName("Cerberus"); } }
        public static ServerName Chocobo { get { return new ServerName("Chocobo"); } }
        public static ServerName Coeurl { get { return new ServerName("Coeurl"); } }
        public static ServerName Diabolos { get { return new ServerName("Diabolos"); } }
        public static ServerName Durandal { get { return new ServerName("Durandal"); } }
        public static ServerName Excalibur { get { return new ServerName("Excalibur"); } }
        public static ServerName Exodus { get { return new ServerName("Exodus"); } }
        public static ServerName Faerie { get { return new ServerName("Faerie"); } }
        public static ServerName Famfrit { get { return new ServerName("Famfrit"); } }
        public static ServerName Fenrir { get { return new ServerName("Fenrir"); } }
        public static ServerName Garuda { get { return new ServerName("Garuda"); } }
        public static ServerName Gilgamesh { get { return new ServerName("Gilgamesh"); } }
        public static ServerName Goblin { get { return new ServerName("Goblin"); } }
        public static ServerName Gungnir { get { return new ServerName("Gungnir"); } }
        public static ServerName Hades { get { return new ServerName("Hades"); } }
        public static ServerName Hyperion { get { return new ServerName("Hyperion"); } }
        public static ServerName Ifrit { get { return new ServerName("Ifrit"); } }
        public static ServerName Ixion { get { return new ServerName("Ixion"); } }
        public static ServerName Jenova { get { return new ServerName("Jenova"); } }
        public static ServerName Kujata { get { return new ServerName("Kujata"); } }
        public static ServerName Lamia { get { return new ServerName("Lamia"); } }
        public static ServerName Leviathan { get { return new ServerName("Leviathan"); } }
        public static ServerName Lich { get { return new ServerName("Lich"); } }
        public static ServerName Louisoix { get { return new ServerName("Louisoix"); } }
        public static ServerName Malboro { get { return new ServerName("Malboro"); } }
        public static ServerName Mandragora { get { return new ServerName("Mandragora"); } }
        public static ServerName Masamune { get { return new ServerName("Masamune"); } }
        public static ServerName Mateus { get { return new ServerName("Mateus"); } }
        public static ServerName Midgardsormr { get { return new ServerName("Midgardsormr"); } }
        public static ServerName Moogle { get { return new ServerName("Moogle"); } }
        public static ServerName Odin { get { return new ServerName("Odin"); } }
        public static ServerName Omega { get { return new ServerName("Omega"); } }
        public static ServerName Pandaemonium { get { return new ServerName("Pandaemonium"); } }
        public static ServerName Phoenix { get { return new ServerName("Phoenix"); } }
        public static ServerName Ragnarok { get { return new ServerName("Ragnarok"); } }
        public static ServerName Ramuh { get { return new ServerName("Ramuh"); } }
        public static ServerName Ridill { get { return new ServerName("Ridill"); } }
        public static ServerName Sargatanas { get { return new ServerName("Sargatanas"); } }
        public static ServerName Shinryu { get { return new ServerName("Shinryu"); } }
        public static ServerName Shiva { get { return new ServerName("Shiva"); } }
        public static ServerName Siren { get { return new ServerName("Siren"); } }
        public static ServerName Tiamat { get { return new ServerName("Tiamat"); } }
        public static ServerName Titan { get { return new ServerName("Titan"); } }
        public static ServerName Tonberry { get { return new ServerName("Tonberry"); } }
        public static ServerName Typhon { get { return new ServerName("Typhon"); } }
        public static ServerName Ultima { get { return new ServerName("Ultima"); } }
        public static ServerName Ultros { get { return new ServerName("Ultros"); } }
        public static ServerName Unicorn { get { return new ServerName("Unicorn"); } }
        public static ServerName Valefor { get { return new ServerName("Valefor"); } }
        public static ServerName Yojimbo { get { return new ServerName("Yojimbo"); } }
        public static ServerName Zalera { get { return new ServerName("Zalera"); } }
        public static ServerName Zeromus { get { return new ServerName("Zeromus"); } }
        public static ServerName Zodiark { get { return new ServerName("Zodiark"); } }
        public static ServerName Spriggan { get { return new ServerName("Spriggan"); } }
        public static ServerName Twintania { get { return new ServerName("Twintania"); } }
        public static ServerName Bismarck { get { return new ServerName("Bismarck"); } }
        public static ServerName Ravana { get { return new ServerName("Ravana"); } }
        public static ServerName Sephirot { get { return new ServerName("Sephirot"); } }
        public static ServerName Sophia { get { return new ServerName("Sophia"); } }
        public static ServerName Zurvan { get { return new ServerName("Zurvan"); } }
        public static ServerName HongYuHai { get { return new ServerName("HongYuHai"); } }
        public static ServerName ShenYiZhiDi { get { return new ServerName("ShenYiZhiDi"); } }
        public static ServerName LaNuoXiYa { get { return new ServerName("LaNuoXiYa"); } }
        public static ServerName HuanYingQunDao { get { return new ServerName("HuanYingQunDao"); } }
        public static ServerName MengYaChi { get { return new ServerName("MengYaChi"); } }
        public static ServerName YuZhouHeYin { get { return new ServerName("YuZhouHeYin"); } }
        public static ServerName WoXianXiRan { get { return new ServerName("WoXianXiRan"); } }
        public static ServerName ChenXiWangZuo { get { return new ServerName("ChenXiWangZuo"); } }
        public static ServerName BaiYinXiang { get { return new ServerName("BaiYinXiang"); } }
        public static ServerName BaiJinHuanXiang { get { return new ServerName("BaiJinHuanXiang"); } }
        public static ServerName ShenQuanHen { get { return new ServerName("ShenQuanHen"); } }
        public static ServerName ChaoFengTing { get { return new ServerName("ChaoFengTing"); } }
        public static ServerName LvRenZhanQiao { get { return new ServerName("LvRenZhanQiao"); } }
        public static ServerName FuXiaoZhiJian { get { return new ServerName("FuXiaoZhiJian"); } }
        public static ServerName Longchaoshendian { get { return new ServerName("Longchaoshendian"); } }
        public static ServerName MengYuBaoJing { get { return new ServerName("MengYuBaoJing"); } }
        public static ServerName ZiShuiZhanQiao { get { return new ServerName("ZiShuiZhanQiao"); } }
        public static ServerName YanXia { get { return new ServerName("YanXia"); } }
        public static ServerName JingYuZhuangYuan { get { return new ServerName("JingYuZhuangYuan"); } }
        public static ServerName MoDuNa { get { return new ServerName("MoDuNa"); } }
        public static ServerName HaiMaoChaWu { get { return new ServerName("HaiMaoChaWu"); } }
        public static ServerName RouFengHaiWan { get { return new ServerName("RouFengHaiWan"); } }
        public static ServerName HuPoYuan { get { return new ServerName("HuPoYuan"); } }
        public static ServerName ShuiJingTa2 { get { return new ServerName("ShuiJingTa2"); } }
        public static ServerName YinLeiHu2 { get { return new ServerName("YinLeiHu2"); } }
        public static ServerName TaiYangHaiAn2 { get { return new ServerName("TaiYangHaiAn2"); } }
        public static ServerName YiXiuJiaDe2 { get { return new ServerName("YiXiuJiaDe2"); } }
        public static ServerName HongChaChuan2 { get { return new ServerName("HongChaChuan2"); } }
    }
}
