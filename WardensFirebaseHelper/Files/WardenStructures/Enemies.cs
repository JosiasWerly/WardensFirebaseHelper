using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardensFirebaseHelper.Structures.Enemies {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AttackProperties {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData {
        public AttackProperties attack_properties { get; set; }
        public EffectProperties effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties weapon_properties { get; set; }

    }

    public class InfoData {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData {
        public ArmamentData armament_data { get; set; }
        public InfoData info_data { get; set; }

    }

    public class EnemyPrimary {
        public AbilityData ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities {
        public EnemyPrimary enemy_primary { get; set; }

    }

    public class AttackProperties2 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties2 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData {
        public int HP { get; set; }
        public AttackProperties2 attack_properties { get; set; }
        public EffectProperties2 effect_properties { get; set; }

    }

    public class InfoData2 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class GoblinBomber {
        public Abilities abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData hp_data { get; set; }
        public InfoData2 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties3 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties3 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties2 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public string RateOfFire { get; set; }

    }

    public class ArmamentData2 {
        public AttackProperties3 attack_properties { get; set; }
        public EffectProperties3 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties2 weapon_properties { get; set; }

    }

    public class InfoData3 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData2 {
        public ArmamentData2 armament_data { get; set; }
        public InfoData3 info_data { get; set; }

    }

    public class EnemyPrimary2 {
        public AbilityData2 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities2 {
        public EnemyPrimary2 enemy_primary { get; set; }

    }

    public class AttackProperties4 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties4 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData2 {
        public int HP { get; set; }
        public AttackProperties4 attack_properties { get; set; }
        public EffectProperties4 effect_properties { get; set; }

    }

    public class InfoData4 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class GoblinCrossbow {
        public Abilities2 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData2 hp_data { get; set; }
        public InfoData4 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties5 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties5 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties3 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData3 {
        public AttackProperties5 attack_properties { get; set; }
        public EffectProperties5 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties3 weapon_properties { get; set; }

    }

    public class InfoData5 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData3 {
        public ArmamentData3 armament_data { get; set; }
        public InfoData5 info_data { get; set; }

    }

    public class EnemyPrimary3 {
        public AbilityData3 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities3 {
        public EnemyPrimary3 enemy_primary { get; set; }

    }

    public class AttackProperties6 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties6 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData3 {
        public int HP { get; set; }
        public AttackProperties6 attack_properties { get; set; }
        public EffectProperties6 effect_properties { get; set; }

    }

    public class InfoData6 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class GoblinGunner {
        public Abilities3 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData3 hp_data { get; set; }
        public InfoData6 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties7 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties7 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties4 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public double RateOfFire { get; set; }

    }

    public class ArmamentData4 {
        public AttackProperties7 attack_properties { get; set; }
        public EffectProperties7 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties4 weapon_properties { get; set; }

    }

    public class InfoData7 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData4 {
        public ArmamentData4 armament_data { get; set; }
        public InfoData7 info_data { get; set; }

    }

    public class EnemyPrimary4 {
        public AbilityData4 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities4 {
        public EnemyPrimary4 enemy_primary { get; set; }

    }

    public class AttackProperties8 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties8 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData4 {
        public int HP { get; set; }
        public AttackProperties8 attack_properties { get; set; }
        public EffectProperties8 effect_properties { get; set; }

    }

    public class InfoData8 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class GoblinMelee {
        public Abilities4 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData4 hp_data { get; set; }
        public InfoData8 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties9 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties9 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties5 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData5 {
        public AttackProperties9 attack_properties { get; set; }
        public EffectProperties9 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties5 weapon_properties { get; set; }

    }

    public class InfoData9 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData5 {
        public ArmamentData5 armament_data { get; set; }
        public InfoData9 info_data { get; set; }

    }

    public class EnemyPrimary5 {
        public AbilityData5 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities5 {
        public EnemyPrimary5 enemy_primary { get; set; }

    }

    public class AttackProperties10 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties10 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData5 {
        public int HP { get; set; }
        public AttackProperties10 attack_properties { get; set; }
        public EffectProperties10 effect_properties { get; set; }

    }

    public class InfoData10 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class Huntress {
        public Abilities5 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData5 hp_data { get; set; }
        public InfoData10 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties11 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties11 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties6 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData6 {
        public AttackProperties11 attack_properties { get; set; }
        public EffectProperties11 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties6 weapon_properties { get; set; }

    }

    public class InfoData11 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData6 {
        public ArmamentData6 armament_data { get; set; }
        public InfoData11 info_data { get; set; }

    }

    public class EnemyPrimary6 {
        public AbilityData6 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities6 {
        public EnemyPrimary6 enemy_primary { get; set; }

    }

    public class AttackProperties12 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties12 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData6 {
        public int HP { get; set; }
        public AttackProperties12 attack_properties { get; set; }
        public EffectProperties12 effect_properties { get; set; }

    }

    public class InfoData12 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class OrcAxeThrower {
        public Abilities6 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData6 hp_data { get; set; }
        public InfoData12 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties13 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties13 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties7 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData7 {
        public AttackProperties13 attack_properties { get; set; }
        public EffectProperties13 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties7 weapon_properties { get; set; }

    }

    public class InfoData13 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData7 {
        public ArmamentData7 armament_data { get; set; }
        public InfoData13 info_data { get; set; }

    }

    public class EnemyComplexmelee {
        public AbilityData7 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class AttackProperties14 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties14 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties8 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData8 {
        public AttackProperties14 attack_properties { get; set; }
        public EffectProperties14 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties8 weapon_properties { get; set; }

    }

    public class InfoData14 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData8 {
        public ArmamentData8 armament_data { get; set; }
        public InfoData14 info_data { get; set; }

    }

    public class EnemyPowerfull {
        public AbilityData8 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class AttackProperties15 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties15 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties9 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData9 {
        public AttackProperties15 attack_properties { get; set; }
        public EffectProperties15 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties9 weapon_properties { get; set; }

    }

    public class InfoData15 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData9 {
        public ArmamentData9 armament_data { get; set; }
        public InfoData15 info_data { get; set; }

    }

    public class EnemySimplemelee {
        public AbilityData9 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class AttackProperties16 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties16 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties10 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData10 {
        public AttackProperties16 attack_properties { get; set; }
        public EffectProperties16 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties10 weapon_properties { get; set; }

    }

    public class InfoData16 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData10 {
        public ArmamentData10 armament_data { get; set; }
        public InfoData16 info_data { get; set; }

    }

    public class EnemySummon {
        public AbilityData10 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities7 {
        public EnemyComplexmelee enemy_complexmelee { get; set; }
        public EnemyPowerfull enemy_powerfull { get; set; }
        public EnemySimplemelee enemy_simplemelee { get; set; }
        public EnemySummon enemy_summon { get; set; }

    }

    public class AttackProperties17 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties17 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData7 {
        public int HP { get; set; }
        public AttackProperties17 attack_properties { get; set; }
        public EffectProperties17 effect_properties { get; set; }

    }

    public class InfoData17 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class OrcCommander {
        public Abilities7 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData7 hp_data { get; set; }
        public InfoData17 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties18 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties18 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties11 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData11 {
        public AttackProperties18 attack_properties { get; set; }
        public EffectProperties18 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties11 weapon_properties { get; set; }

    }

    public class InfoData18 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData11 {
        public ArmamentData11 armament_data { get; set; }
        public InfoData18 info_data { get; set; }

    }

    public class EnemyPrimary7 {
        public AbilityData11 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities8 {
        public EnemyPrimary7 enemy_primary { get; set; }

    }

    public class AttackProperties19 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties19 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData8 {
        public int HP { get; set; }
        public AttackProperties19 attack_properties { get; set; }
        public EffectProperties19 effect_properties { get; set; }

    }

    public class InfoData19 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class OrcCrossbow {
        public Abilities8 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData8 hp_data { get; set; }
        public InfoData19 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties20 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties20 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties12 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData12 {
        public AttackProperties20 attack_properties { get; set; }
        public EffectProperties20 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties12 weapon_properties { get; set; }

    }

    public class InfoData20 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData12 {
        public ArmamentData12 armament_data { get; set; }
        public InfoData20 info_data { get; set; }

    }

    public class EnemyPrimary8 {
        public AbilityData12 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities9 {
        public EnemyPrimary8 enemy_primary { get; set; }

    }

    public class AttackProperties21 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties21 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData9 {
        public int HP { get; set; }
        public AttackProperties21 attack_properties { get; set; }
        public EffectProperties21 effect_properties { get; set; }

    }

    public class InfoData21 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class OrcMelee {
        public Abilities9 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData9 hp_data { get; set; }
        public InfoData21 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties22 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties22 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties13 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public double RateOfFire { get; set; }

    }

    public class ArmamentData13 {
        public AttackProperties22 attack_properties { get; set; }
        public EffectProperties22 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties13 weapon_properties { get; set; }

    }

    public class InfoData22 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData13 {
        public ArmamentData13 armament_data { get; set; }
        public InfoData22 info_data { get; set; }

    }

    public class EnemyPrimary9 {
        public AbilityData13 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities10 {
        public EnemyPrimary9 enemy_primary { get; set; }

    }

    public class AttackProperties23 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties23 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData10 {
        public int HP { get; set; }
        public AttackProperties23 attack_properties { get; set; }
        public EffectProperties23 effect_properties { get; set; }

    }

    public class InfoData23 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class ShamanFireball {
        public Abilities10 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData10 hp_data { get; set; }
        public InfoData23 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties24 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties24 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties14 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData14 {
        public AttackProperties24 attack_properties { get; set; }
        public EffectProperties24 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties14 weapon_properties { get; set; }

    }

    public class InfoData24 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData14 {
        public ArmamentData14 armament_data { get; set; }
        public InfoData24 info_data { get; set; }

    }

    public class EnemyPrimary10 {
        public AbilityData14 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities11 {
        public EnemyPrimary10 enemy_primary { get; set; }

    }

    public class AttackProperties25 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties25 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData11 {
        public int HP { get; set; }
        public AttackProperties25 attack_properties { get; set; }
        public EffectProperties25 effect_properties { get; set; }

    }

    public class InfoData25 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class ShamanFirecaller {
        public Abilities11 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData11 hp_data { get; set; }
        public InfoData25 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties26 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties26 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties15 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData15 {
        public AttackProperties26 attack_properties { get; set; }
        public EffectProperties26 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties15 weapon_properties { get; set; }

    }

    public class InfoData26 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData15 {
        public ArmamentData15 armament_data { get; set; }
        public InfoData26 info_data { get; set; }

    }

    public class EnemyPrimary11 {
        public AbilityData15 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities12 {
        public EnemyPrimary11 enemy_primary { get; set; }

    }

    public class AttackProperties27 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties27 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData12 {
        public int HP { get; set; }
        public AttackProperties27 attack_properties { get; set; }
        public EffectProperties27 effect_properties { get; set; }

    }

    public class InfoData27 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class TrollMelee {
        public Abilities12 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData12 hp_data { get; set; }
        public InfoData27 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties28 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties28 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties16 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData16 {
        public AttackProperties28 attack_properties { get; set; }
        public EffectProperties28 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties16 weapon_properties { get; set; }

    }

    public class InfoData28 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData16 {
        public ArmamentData16 armament_data { get; set; }
        public InfoData28 info_data { get; set; }

    }

    public class EnemyPrimary12 {
        public AbilityData16 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities13 {
        public EnemyPrimary12 enemy_primary { get; set; }

    }

    public class AttackProperties29 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties29 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData13 {
        public int HP { get; set; }
        public AttackProperties29 attack_properties { get; set; }
        public EffectProperties29 effect_properties { get; set; }

    }

    public class InfoData29 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class TrollRanged {
        public Abilities13 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData13 hp_data { get; set; }
        public InfoData29 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class AttackProperties30 {
        public int AOEDamage { get; set; }
        public int AOERadius { get; set; }
        public int Damage { get; set; }
        public string eType { get; set; }

    }

    public class EffectProperties30 {
        public int Duration { get; set; }
        public int EffectChange { get; set; }
        public int RetryTime { get; set; }
        public string eType { get; set; }

    }

    public class WeaponProperties17 {
        public int ActivationDelay { get; set; }
        public int ClipSize { get; set; }
        public int Cooldown { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }

    }

    public class ArmamentData17 {
        public AttackProperties30 attack_properties { get; set; }
        public EffectProperties30 effect_properties { get; set; }
        public List<string> tags_to_damage { get; set; }
        public WeaponProperties17 weapon_properties { get; set; }

    }

    public class InfoData30 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class AbilityData17 {
        public ArmamentData17 armament_data { get; set; }
        public InfoData30 info_data { get; set; }

    }

    public class EnemyPrimary13 {
        public AbilityData17 ability_data { get; set; }
        public bool canBeInterupted { get; set; }
        public bool canBeUsedInAir { get; set; }
        public int cooldown { get; set; }
        public int customMontageTime { get; set; }
        public int maxUses { get; set; }

    }

    public class Abilities14 {
        public EnemyPrimary13 enemy_primary { get; set; }

    }

    public class AttackProperties31 {
        public int Energy { get; set; }
        public int Fire { get; set; }
        public int Ice { get; set; }
        public int Lighting { get; set; }
        public int Physical { get; set; }

    }

    public class EffectProperties31 {
        public int Bleed { get; set; }
        public int Blind { get; set; }
        public int Freeze { get; set; }
        public int Slow { get; set; }
        public int Stun { get; set; }

    }

    public class HpData14 {
        public int HP { get; set; }
        public AttackProperties31 attack_properties { get; set; }
        public EffectProperties31 effect_properties { get; set; }

    }

    public class InfoData31 {
        public string DisplayName { get; set; }
        public string LargeDescription { get; set; }
        public string ShortDescription { get; set; }

    }

    public class WolfRider {
        public Abilities14 abilities { get; set; }
        public string classification { get; set; }
        public int dangerLevel { get; set; }
        public HpData14 hp_data { get; set; }
        public InfoData31 info_data { get; set; }
        public int perceptionRange { get; set; }
        public int souls { get; set; }
        public int speed { get; set; }

    }

    public class Enemies {
        public GoblinBomber goblin_bomber { get; set; }
        public GoblinCrossbow goblin_crossbow { get; set; }
        public GoblinGunner goblin_gunner { get; set; }
        public GoblinMelee goblin_melee { get; set; }
        public Huntress huntress { get; set; }
        public OrcAxeThrower orc_axe_thrower { get; set; }
        public OrcCommander orc_commander { get; set; }
        public OrcCrossbow orc_crossbow { get; set; }
        public OrcMelee orc_melee { get; set; }
        public ShamanFireball shaman_fireball { get; set; }
        public ShamanFirecaller shaman_firecaller { get; set; }
        public TrollMelee troll_melee { get; set; }
        public TrollRanged troll_ranged { get; set; }
        public WolfRider wolf_rider { get; set; }

    }

    public class Root {
        public Enemies Enemies { get; set; }

    }
}