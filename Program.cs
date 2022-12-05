//----- C# II (Dor Ben Dor) ------
//          Tal Tsadikov
//--------------------------------

using Berzerkers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using static Berzerkers.Unit;

CombatSystem cb = new CombatSystem();

List<Unit> playerArmy = cb.GeneratePlayerArmy();
List<Unit> enemyArmy = cb.GenerateEnemyArmy();

cb.Combat(playerArmy, enemyArmy);