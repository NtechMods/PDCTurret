using System.IO;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef.SpawnType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef.PushPullDef.Force;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.Texture;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.TracerBaseDef;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
				private AmmoDef NATO_Ammo => new AmmoDef
        {
          
                AmmoMagazine = "NATO_25x184mm",
                AmmoRound = "NATO_Ammo",
                HybridRound = false, //AmmoMagazine based weapon with energy cost
                EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
                BaseDamage = 39.5f,
                Mass = 1f, // in kilograms
                Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 20.2f,
				HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
                IgnoreWater = false,

                Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
                {
                    Shape = LineShape,
                    Diameter = 1,
                },
                ObjectsHit = new ObjectsHitDef
                {
                    MaxObjectsHit = 0, // 0 = disabled
                    CountBlocks = false, // counts gridBlocks and not just entities hit
                },
                Shrapnel = new ShrapnelDef
				{
					AmmoRound = "",
					Fragments = 12,
					Degrees = 90,
					Reverse = false,
					RandomizeDir = false,
				},
				Pattern = new AmmoPatternDef
				{
					Ammos = new[] {
						"",
					},
					Enable = false,
					TriggerChance = 1f,
					Random = false,
					RandomMin = 1,
					RandomMax = 1,
					SkipParent = false,
				},
                DamageScales = new DamageScaleDef
                {
                    MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                    DamageVoxels = false, // true = voxels are vulnerable to this weapon
                    SelfDamage = false, // true = allow self damage.
                    HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                    VoxelHitModifier = 10,
                    // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                    Characters = 1.2f,
					FallOff = new FallOffDef
					{
						Distance = 1000f, // Distance at which max damage begins falling off.
						MinMultipler = 0.25f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
					},
                    Grids = new GridSizeDef
                    {
                        Large = -1f,
                        Small = -1f,
                    },
                    Armor = new ArmorDef
                    {
                        Armor = 0.9f,
                        Light = 0.9f,
                        Heavy = 0.7f,
                        NonArmor = 1f,
                    },
                    Shields = new ShieldDef
                    {
                        Modifier = 1.1f,
                        Type = Kinetic,
                        BypassModifier = -1f,
                    },
                    // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                    Custom = new CustomScalesDef
                    {
                        IgnoreAllOthers = false,
                        Types = new []
                        {
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test1",
                                Modifier = -1f,
                            },
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test2",
                                Modifier = -1f,
                            },
                        },
                    },
                },
                AreaEffect = new AreaDamageDef
                {
                    AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                    AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 70f,
                    Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 100,
                    GrowTime = 100,
                    HideModel = false,
                    ShowParticle = false,
                    Particle = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                },
                    Explosions = new ExplosionDef
                    {
                        NoVisuals = false,
                        NoSound = false,
                        Scale = 1,
                        CustomParticle = "",
                        CustomSound = "",
                    },
                    Detonation = new DetonateDef
                    {
                        DetonateOnEnd = false,
                        ArmOnlyOnHit = false,
                        DetonationDamage = 1,
                        DetonationRadius = 1,
                        MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)
                    },
                    EwarFields = new EwarFieldsDef
                    {
                        Duration = 60,
                        StackDuration = true,
                        Depletable = false,
                        MaxStacks = 10,
                        TriggerRange = 5f,
                        DisableParticleEffect = true,
                        Force = new PushPullDef // AreaEffectDamage is multiplied by target mass.
                        {
                           ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                           ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                           Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        },
                    },
                },
                Beams = new BeamDef
                {
                    Enable = false,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = false, // Only spawn one particle hit per beam weapon.
                },
                Trajectory = new TrajectoryDef
                {
                    Guidance = None,
                    TargetLossDegree = 180f,
                    TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 0f,
                    DesiredSpeed = 777,
                    MaxTrajectory = 1200f,
                    FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                    GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                    SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                    RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                    MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.

                    Smarts = new SmartsDef
                    {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                    },
                    Mines = new MinesDef
                    {
                        DetectRadius =  200,
                        DeCloakRadius = 100,
                        FieldTime = 1800,
                        Cloak = true,
                        Persist = false,
                    },
                },
                AmmoGraphics = new GraphicDef
                {
                    ModelName = "",
                    VisualProbability = 0.85f,
                    ShieldHitDraw = true,
                    Particles = new AmmoParticleDef
                    {
                        Ammo = new ParticleDef
                        {
                            Name = "", //ShipWelderArc
                            ShrinkByDistance = false,
                            Color = Color(red: 8, green: 0, blue: 0, alpha: 32),
                            Offset = Vector(x: 0, y: -1, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 2000,
                                MaxDuration = 1,
                                Scale = 1,
                            },
                        },
                        Hit = new ParticleDef
                        {
                            Name = "MaterialHit_Metal",
                            ApplyToShield = true,
                            ShrinkByDistance = true,
                            Color = Color(red: 3, green: 2, blue: 1, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = false,
                                Restart = false,
                                MaxDistance = 500,
                                MaxDuration = 1,
                                Scale = 1,
                                HitPlayChance = 0.1f,
                            },
                        },
                        Eject = new ParticleDef
                        {
                            Name = "",
                            ApplyToShield = true,
                            ShrinkByDistance = false,
                            Color = Color(red: 3, green: 1.9f, blue: 1f, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 5000,
                                MaxDuration = 30,
                                Scale = 1,
                                HitPlayChance = 1f,
                            },
                        },
                    },
                    Lines = new LineDef
                    {
                        TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                        ColorVariance = Random(start: 5f, end: 10f), // multiply the color by random values within range.
                        WidthVariance = Random(start: 0f, end: 0.045f), // adds random value to default width (negatives shrinks width)
                        Tracer = new TracerBaseDef
                        {
							Enable = true,
							Length = 3f,
							Width = 0.05f,
							Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
							VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
							VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
							Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "ProjectileTrailLine",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = false, // If true Tracer TextureMode is ignored
                            Textures = new[] {
								"",
                            },
                            SegmentLength = 0f, // Uses the values below.
                            SegmentGap = 0f, // Uses Tracer textures and values
                            Speed = 1f, // meters per second
								Color = Color(red: 2.9f, green: 1.7f, blue: 0.1f, alpha: 1),

								WidthMultiplier = 1f,
								Reverse = false,
								UseLineVariance = false,
								WidthVariance = Random(start: 0f, end: 0f),
								ColorVariance = Random(start: 0f, end: 0f)
							}
						},
                        Trail = new TrailDef
                        {
                            Enable = false,
                            Textures = new[] {
						    	"",
                            },
                            TextureMode = Normal,
                            DecayTime = 128,
                            Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                            Back = false,
                            CustomWidth = 0,
                            UseWidthVariance = false,

                            UseColorFade = true,
                        },
                        OffsetEffect = new OffsetEffectDef
                        {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                        },
                    },
                },
                AmmoAudio = new AmmoAudioDef
                {
                    TravelSound = "",
                    HitSound = "ArcImpMetalMetalCat0",
					ShieldHitSound = "",
					PlayerHitSound = "",
					VoxelHitSound = "",
					FloatingHitSound = "",
					HitPlayChance = 0.7f,
					HitPlayShield = true,
                }, // Don't edit below this line
            Ejection = new AmmoEjectionDef
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemDefinition = "", //InventoryComponent name
                    LifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            },


        };
		
		
		
		
		
        private AmmoDef NDeU_Ammo => new AmmoDef
        {
          
                AmmoMagazine = "DeU_25x184mm",
                AmmoRound = "NDeU_Ammo",
                HybridRound = false, //AmmoMagazine based weapon with energy cost
                EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
                BaseDamage = 50.5f,
                Mass = 1f, // in kilograms
                Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 3.2f,
				HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
                IgnoreWater = false,
                
                Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
                {
                    Shape = LineShape,
                    Diameter = 1,
                },
                ObjectsHit = new ObjectsHitDef
                {
                    MaxObjectsHit = 0, // 0 = disabled
                    CountBlocks = false, // counts gridBlocks and not just entities hit
                },
                Shrapnel = new ShrapnelDef
				{
					AmmoRound = "",
					Fragments = 12,
					Degrees = 90,
					Reverse = false,
					RandomizeDir = false,
				},
				Pattern = new AmmoPatternDef
				{
					Ammos = new[] {
						"",
					},
					Enable = false,
					TriggerChance = 1f,
					Random = false,
					RandomMin = 1,
					RandomMax = 1,
					SkipParent = false,
                    PatternSteps = 1, // Number of Ammos activated per round, will progress in order and loop.  Ignored if Random = true.
           		},
                DamageScales = new DamageScaleDef
                {
                    MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                    DamageVoxels = false, // true = voxels are vulnerable to this weapon
                    SelfDamage = false, // true = allow self damage.
                    HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                    VoxelHitModifier = 10,
                    // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                    Characters = 1.2f,
					FallOff = new FallOffDef
					{
						Distance = 1000f, // Distance at which max damage begins falling off.
						MinMultipler = 0.25f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
					},
                    Grids = new GridSizeDef
                    {
                        Large = -1f,
                        Small = -1f,
                    },
                    Armor = new ArmorDef
                    {
                        Armor = 0.9f,
                        Light = 1.3f,
                        Heavy = 1.1f,
                        NonArmor = 1f,
                    },
                    Shields = new ShieldDef
                    {
                        Modifier = 1.5f,
                        Type = Kinetic,
                        BypassModifier = -1f,
                    },
                    // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                    Custom = new CustomScalesDef
                    {
                        IgnoreAllOthers = false,
                        Types = new []
                        {
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test1",
                                Modifier = -1f,
                            },
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test2",
                                Modifier = -1f,
                            },
                        },
                    },
                },
                AreaEffect = new AreaDamageDef																																	  
                {
                    AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                    AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 70f,
                    Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 100,
                    GrowTime = 100,
                    HideModel = false,
                    ShowParticle = false,
                    Particle = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                },
                    Explosions = new ExplosionDef
                    {
                        NoVisuals = false,
                        NoSound = false,
                        Scale = 1,
                        CustomParticle = "",
                        CustomSound = "",
                    },
                    Detonation = new DetonateDef
                    {
                        DetonateOnEnd = false,
                        ArmOnlyOnHit = false,
                        DetonationDamage = 1,
                        DetonationRadius = 1,
                        MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)
                    },
                    EwarFields = new EwarFieldsDef
                    {
                        Duration = 60,
                        StackDuration = true,
                        Depletable = false,
                        MaxStacks = 10,
                        TriggerRange = 5f,
                        DisableParticleEffect = true,
                        Force = new PushPullDef // AreaEffectDamage is multiplied by target mass.
                        {
                            ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                            ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                            Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        },
                    },
                },
                Beams = new BeamDef
                {
                    Enable = false,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = false, // Only spawn one particle hit per beam weapon.
                },
                Trajectory = new TrajectoryDef
                {
                    Guidance = None,
                    TargetLossDegree = 180f,
                    TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 0f,
                    DesiredSpeed = 777,
                    MaxTrajectory = 1200f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
                    Smarts = new SmartsDef
                    {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                    },
                    Mines = new MinesDef
                    {
                        DetectRadius =  200,
                        DeCloakRadius = 100,
                        FieldTime = 1800,
                        Cloak = true,
                        Persist = false,
                    },
                },
                AmmoGraphics = new GraphicDef
                {
                    ModelName = "",
                    VisualProbability = 0.85f,
                    ShieldHitDraw = true,
                    Particles = new AmmoParticleDef
                    {
                        Ammo = new ParticleDef
                        {
                            Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                            Color = Color(red: 8, green: 0, blue: 0, alpha: 32),
                            Offset = Vector(x: 0, y: -1, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 2000,
                                MaxDuration = 1,
                                Scale = 1,
                            },
                        },
                        Hit = new ParticleDef
                        {
                            Name = "MaterialHit_Metal",
                            ApplyToShield = true,
                            ShrinkByDistance = true,
                            Color = Color(red: 3, green: 2, blue: 1, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = false,
                                Restart = false,
                                MaxDistance = 500,
                                MaxDuration = 1,
                                Scale = 1,
                                HitPlayChance = 0.1f,
                            },
                        },
                        Eject = new ParticleDef
                        {
                            Name = "",
                            ApplyToShield = true,
                            ShrinkByDistance = false,
                            Color = Color(red: 3, green: 1.9f, blue: 1f, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 5000,
                                MaxDuration = 30,
                                Scale = 1,
                                HitPlayChance = 1f,
                            },
                        },
                    },
                    Lines = new LineDef
                    {
                        TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                        ColorVariance = Random(start: 5f, end: 10f), // multiply the color by random values within range.
                        WidthVariance = Random(start: 0f, end: 0.045f), // adds random value to default width (negatives shrinks width)
                        Tracer = new TracerBaseDef
                        {
							Enable = true,
							Length = 2.5f,
							Width = 0.2f,
							Color = Color(red: 2.9f, green: 1.7f, blue: 0.1f, alpha: 1),
							VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
							VisualFadeEnd = 10, // How many ticks after fade began before it will be invisible.
							Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "ProjectileTrailLine",
                        },
                        TextureMode = Chaos, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = false, // If true Tracer TextureMode is ignored
                            Textures = new[] {
								"",
                            },
								SegmentLength = 5f,
								SegmentGap = 1f,
								Speed = 0f,
								Color = Color(red: 2.9f, green: 1.7f, blue: 0.1f, alpha: 1),
								WidthMultiplier = 1f,
								Reverse = false,
								UseLineVariance = false,
								WidthVariance = Random(start: 0f, end: 0f),
								ColorVariance = Random(start: 0f, end: 0f)
							}
						},

                    Trail = new TrailDef
                    {
                        Enable = false,
                        Textures = new[] {
							"ProjectileTrailLine",
                        },
                        TextureMode = Normal,
                        DecayTime = 60,
                        Color = Color(red: 1, green: 1, blue: 10, alpha: 1),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                    },
                },
                AmmoAudio = new AmmoAudioDef
                {
                    TravelSound = "",
                    HitSound = "ArcImpMetalMetalCat0",
					ShieldHitSound = "",
					PlayerHitSound = "",
					VoxelHitSound = "",
					FloatingHitSound = "",
					HitPlayChance = 0.5f,
					HitPlayShield = true,
                }, // Don't edit below this line
            Ejection = new AmmoEjectionDef
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemDefinition = "", //InventoryComponent name
                    LifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            },


        };



        private AmmoDef MissileAmmos => new AmmoDef
        {
            
                AmmoMagazine = "Missile200mm",
                AmmoRound = "MissileAmmos",
                HybridRound = false, //AmmoMagazine based weapon with energy cost
                EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
                BaseDamage = 1f,
                Mass = 45f, // in kilograms
                Health = 1, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 1f,

                Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
                {
                    Shape = LineShape,
                    Diameter = 0,
                },
                ObjectsHit = new ObjectsHitDef
                {
                    MaxObjectsHit = 0, // 0 = disabled
                    CountBlocks = false, // counts gridBlocks and not just entities hit
                },
                Shrapnel = new ShrapnelDef
				{
					AmmoRound = "",
					Fragments = 12,
					Degrees = 90,
					Reverse = false,
					RandomizeDir = false,
				},
                DamageScales = new DamageScaleDef
                {
                    MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                    DamageVoxels = false, // true = voxels are vulnerable to this weapon
                    SelfDamage = false, // true = allow self damage.
                    HealthHitModifier = 1, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                    VoxelHitModifier = -1,
                    // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                    Characters = 0.2f,
                    Grids = new GridSizeDef
                    {
                        Large = -1f,
                        Small = -1f,
                    },
                    Armor = new ArmorDef
                    {
                        Armor = 1f,
                        Light = 0.9f,
                        Heavy = 0.7f,
                        NonArmor = 1.2f,
                    },
                    Shields = new ShieldDef
                    {
                        Modifier = -1f,
                        Type = Kinetic,
                        BypassModifier = -1f,
                    },
                    // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                    Custom = new CustomScalesDef
                    {
                        IgnoreAllOthers = false,
                        Types = new []
                        {
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test1",
                                Modifier = -1f,
                            },
                            new CustomBlocksDef
                            {
                                SubTypeId = "Test2",
                                Modifier = -1f,
                            },
                        },
                    },
                },
                AreaEffect = new AreaDamageDef
                {
                    AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                    AreaEffectDamage = 500f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 4f,
                    Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                    {
                        Interval = 30,
                        PulseChance = 0,
                    },
                    Explosions = new ExplosionDef
                    {
                        NoVisuals = false,
                        NoSound = false,
                        Scale = 1,
                        CustomParticle = "",
                        CustomSound = "",
                    },
                    Detonation = new DetonateDef
                    {
                        DetonateOnEnd = true,
                        ArmOnlyOnHit = false,
                        DetonationDamage = 0,
                        DetonationRadius = 2,
                    },
                    EwarFields = new EwarFieldsDef
                    {
                        Duration = 0,
                        StackDuration = true,
                        Depletable = false,
                        MaxStacks = 10,
                        TriggerRange = 5f,
                    },
                },
                Beams = new BeamDef
                {
                    Enable = false,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = false, // Only spawn one particle hit per beam weapon.
                },
                Trajectory = new TrajectoryDef
                {
                    Guidance = None,
                    TargetLossDegree = 180f,
                    TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 900f,
                    DesiredSpeed = 200,
                    MaxTrajectory = 800f,
                    FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                    SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                    RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                    Smarts = new SmartsDef
                    {
                        Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                        Aggressiveness = 0.1f, // controls how responsive tracking is.
                        MaxLateralThrust = 0.05f, // controls how sharp the trajectile may turn
                        TrackingDelay = 400, // Measured in Shape diameter units traveled.
                        MaxChaseTime = 2000, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                        OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    },
                    Mines = new MinesDef
                    {
                        DetectRadius =  200,
                        DeCloakRadius = 100,
                        FieldTime = 1800,
                        Cloak = true,
                        Persist = false,
                    },
                },
                AmmoGraphics = new GraphicDef
                {
                    ModelName = "\\Models\\Weapons\\Projectile_Missile.mwm",
                    VisualProbability = 1f,
                    ShieldHitDraw = true,
                    Particles = new AmmoParticleDef
                    {
                        Ammo = new ParticleDef
                        {
                            Name = "MissileSmokeTrail", //ShipWelderArc, Smoke_Missile, Damage_HeavyMech_Damaged, MissileSmokeTrail
                            Color = Color(red: 1f, green: 1f, blue: 1f, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = true,
                                Restart = false,
                                MaxDistance = 5000,
                                MaxDuration = 1,
                                Scale = 1.0f,
                            },
                        },
                        Hit = new ParticleDef
                        {
                            Name = "",
                            ApplyToShield = true,
                            ShrinkByDistance = true,
                            Color = Color(red: 3, green: 2, blue: 1, alpha: 1),
                            Offset = Vector(x: 0, y: 0, z: 0),
                            Extras = new ParticleOptionDef
                            {
                                Loop = false,
                                Restart = false,
                                MaxDistance = 500,
                                MaxDuration = 1,
                                Scale = 1,
                                HitPlayChance = 1f,
                            },
                        },
                    },
                    Lines = new LineDef
                    {
                        TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                        ColorVariance = Random(start: 5f, end: 10f), // multiply the color by random values within range.
                        WidthVariance = Random(start: 0f, end: 0.045f), // adds random value to default width (negatives shrinks width)
                        Tracer = new TracerBaseDef
                        {
                            Enable = false,
                            Length = 3f,
                            Width = 0.05f,
                            Color = Color(red: 0.9f, green: 0.9f, blue: 0.9f, alpha: 1),
                        },
                        Trail = new TrailDef
                        {
                            Enable = false,
                            Material = "WeaponLaser",
                            DecayTime = 128,
                            Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                            Back = true,
                            CustomWidth = 0,
                            UseWidthVariance = false,
                            UseColorFade = true,
                        },
                        OffsetEffect = new OffsetEffectDef
                        {
                            MaxOffset =  0,// 0 offset value disables this effect
                            MinLength = 0.2f,
                            MaxLength = 3,
                        },
                    },
                },
                AmmoAudio = new AmmoAudioDef
                {
                    TravelSound = "",
                    HitSound = "ArcImpMetalMetalCat0",
                    HitPlayChance = 0.1f,
                    HitPlayShield = true,
                }, // Don't edit below this line

        };

	

    }
}