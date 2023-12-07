namespace aoc._2023
{
    internal static class Day5
    {
        private static readonly string TestInput = "seeds: 79 14 55 13\r\n\r\nseed-to-soil map:\r\n50 98 2\r\n52 50 48\r\n\r\nsoil-to-fertilizer map:\r\n0 15 37\r\n37 52 2\r\n39 0 15\r\n\r\nfertilizer-to-water map:\r\n49 53 8\r\n0 11 42\r\n42 0 7\r\n57 7 4\r\n\r\nwater-to-light map:\r\n88 18 7\r\n18 25 70\r\n\r\nlight-to-temperature map:\r\n45 77 23\r\n81 45 19\r\n68 64 13\r\n\r\ntemperature-to-humidity map:\r\n0 69 1\r\n1 0 69\r\n\r\nhumidity-to-location map:\r\n60 56 37\r\n56 93 4";
        private static readonly string Input = "seeds: 1636419363 608824189 3409451394 227471750 12950548 91466703 1003260108 224873703 440703838 191248477 634347552 275264505 3673953799 67839674 2442763622 237071609 3766524590 426344831 1433781343 153722422\r\n\r\nseed-to-soil map:\r\n2067746708 2321931404 124423068\r\n2774831547 3357841131 95865403\r\n3776553292 3323317283 34523848\r\n4167907733 3453706534 116376261\r\n1190847573 767701596 554806188\r\n2870696950 1975607604 173919437\r\n1980384731 2612856575 87361977\r\n3380570559 2987564153 335753130\r\n3044616387 2451131599 21188806\r\n3909556885 2167390152 154541252\r\n3811077140 2149527041 17863111\r\n4077167815 3804196813 90739918\r\n2528751611 4222771775 72195521\r\n4064098137 3894936731 13069678\r\n4284283994 2700218552 10683302\r\n2468832075 2472320405 59919536\r\n3716323689 3570082795 60229603\r\n1085396685 662250708 105450888\r\n1030174777 1322507784 22912174\r\n1975607604 2446354472 4777127\r\n3828940251 2532239941 80616634\r\n584992388 1930412346 7315040\r\n592307428 0 437867349\r\n1745653761 437867349 224383359\r\n0 1345419958 584992388\r\n2192169776 2710901854 276662299\r\n2600947132 3630312398 173884415\r\n1053086951 1937727386 32309734\r\n3065805193 3908006409 314765366\r\n\r\nsoil-to-fertilizer map:\r\n4148533839 3658735071 146433457\r\n656556737 471425735 68165409\r\n751630557 539591144 462446129\r\n724722146 1002037273 26908411\r\n0 24799538 226917727\r\n4049709448 3143711443 98824391\r\n412048729 251717265 219708470\r\n3321838617 2645077606 72145759\r\n3869354568 2464722726 180354880\r\n2044900648 1380852911 42721698\r\n226917727 1028945684 185131002\r\n3111204505 2717223365 210634112\r\n2129227343 1423574609 981977162\r\n1380852911 2927857477 215853966\r\n3393984376 2405551771 59170955\r\n3453155331 3242535834 416199237\r\n1596706877 3805168528 448193771\r\n2087622346 4253362299 41604997\r\n631757199 0 24799538\r\n\r\nfertilizer-to-water map:\r\n2679101382 2898500255 208361454\r\n3672966601 3700867560 107718031\r\n1764241275 4242224976 41519499\r\n1018987051 346629037 49456831\r\n518817716 396085868 3722249\r\n1224466235 306138732 40490305\r\n1068679130 947256497 122607155\r\n1328820253 625833852 156797976\r\n222363356 782631828 128136603\r\n4106081288 2497628211 144953761\r\n2887462836 1577782207 70654427\r\n2453719866 2077230479 225381516\r\n2177283137 3415053348 9638645\r\n1485618229 910768431 36488066\r\n1805760774 2833622399 32168430\r\n482104460 0 36713256\r\n4065926174 2480721173 16907038\r\n118194361 213050410 93088322\r\n1869091498 3106861709 308191639\r\n1068443882 399808117 235248\r\n2958117263 3926610020 315614956\r\n1577782207 2324396806 156324367\r\n1270677460 36713256 58142793\r\n1264956540 586932982 5720920\r\n1847306687 2302611995 21784811\r\n843178107 411124038 175808944\r\n1191286285 592653902 33179950\r\n4251035049 4283744475 11222821\r\n4262257870 2865790829 32709426\r\n4082833212 2810374323 23248076\r\n3273732219 2642581972 167792351\r\n350499959 1069863652 131604501\r\n3780684632 1859496740 217733739\r\n3441524570 3808585591 118024429\r\n3998418371 1791988937 67507803\r\n1837929204 3691490077 9377483\r\n1734106574 1761854236 30134701\r\n211282683 400043365 11080673\r\n2186921782 3424691993 266798084\r\n522539965 1201468153 320638142\r\n3559548999 1648436634 113417602\r\n0 94856049 118194361\r\n\r\nwater-to-light map:\r\n487890089 1253174910 48217379\r\n1162866447 2295971038 331509140\r\n3115016077 4085918002 209049294\r\n3600618057 2743705059 694349239\r\n3021490874 3712826169 26810261\r\n2743705059 3739636430 3013944\r\n3048301135 4019203060 66714942\r\n1494375587 0 650888870\r\n167398115 650888870 320491974\r\n78943404 2207516327 88454711\r\n3324065371 3742650374 276552686\r\n881072381 1174877356 78297554\r\n2690077973 2191170718 16345609\r\n2746719003 3438054298 274771871\r\n2145264457 1301392289 544813516\r\n959369935 971380844 203496512\r\n536107468 1846205805 344964913\r\n0 2627480178 78943404\r\n\r\nlight-to-temperature map:\r\n2934276762 3692860946 134937994\r\n2222730788 3468116804 32924074\r\n2030910720 3501040878 191820068\r\n2876227610 3450265581 17851223\r\n2821863146 1926340324 54364464\r\n2894078833 3827798940 40197929\r\n0 2499885250 950380331\r\n3069214756 1312743837 613596487\r\n950380331 232213448 1080530389\r\n2302682684 2382183979 117701271\r\n3682811243 47027822 185185626\r\n2255654862 0 47027822\r\n2420383955 1980704788 401479191\r\n\r\ntemperature-to-humidity map:\r\n3474899002 2152529659 335631613\r\n1227362297 2657517973 1047434675\r\n1147289328 4214894327 80072969\r\n3069802422 3704952648 405096580\r\n4233143053 2090705416 61824243\r\n3979887316 1837449679 253255737\r\n3810530615 2488161272 169356701\r\n1042444229 4110049228 104845099\r\n2274796972 1042444229 718141444\r\n2992938416 1760585673 76864006\r\n\r\nhumidity-to-location map:\r\n2905941546 1669212802 106379169\r\n3490393041 2571512629 24111360\r\n3327134512 896350741 163258529\r\n163044169 321738120 136537257\r\n1794114599 1475899779 31051829\r\n1155727752 771777629 98456450\r\n3514504401 1890601528 199093442\r\n3241757362 1290456090 8146812\r\n3713597843 2595623989 446677438\r\n2865335819 1388663285 15697510\r\n3155553665 2166925308 86203697\r\n26879537 567441866 52236777\r\n421556320 59735378 198122323\r\n4160275281 1059609270 134692015\r\n1072793086 2488577963 82934666\r\n2006477848 3530988938 680918581\r\n1766297705 1528152733 5360386\r\n1405780686 3214887893 74444149\r\n3017788788 1533513119 135699683\r\n977736160 4211907519 83059777\r\n1771658091 2466121455 22456508\r\n2687396429 870234079 26116662\r\n79116314 547394430 20047436\r\n2773054926 1506951608 21201125\r\n1825166428 3289332042 181311420\r\n2713513091 1404360795 59541835\r\n3012320715 1213908249 5468073\r\n3249904174 2089694970 77230338\r\n2794256051 1219376322 71079768\r\n1601513875 2253129005 74723447\r\n3153488471 769712435 2065194\r\n299581426 41300579 18434799\r\n332437267 458275377 89119053\r\n1273791166 2327852452 131989520\r\n1676237322 1298602902 90060383\r\n318016225 26879537 14421042\r\n769712435 3470643462 60345476\r\n2881033329 3042301427 24908217\r\n1480224835 2459841972 6279483\r\n99163750 257857701 63880419\r\n1060795937 1463902630 11997149\r\n830057911 3067209644 147678249\r\n1254184202 1194301285 19606964\r\n1486504318 1775591971 115009557";
        private static List<string> _lines = Utilities.StringToLines(Input);
        private static List<long> _seeds = new List<long>();
        private static List<MapType> _masterMapList = new List<MapType>();

        private static List<long[]> _seedRangePairs = new List<long[]>();

        internal static long Part1()
        {
            long result = long.MaxValue;

            var seedsLine = _lines[0];
            var cutSeedsLine = seedsLine.Substring(seedsLine.IndexOf(':') + 1).Trim();
            _seeds = cutSeedsLine.Split(" ").Select(s => long.Parse(s)).ToList();

            InitialiseMaps();

            foreach (var seed in _seeds)
            {
                long location = GetLocationFromSeed(seed);
                // Console.WriteLine($"Testing seed {seed}. Found location: {location}");
                if (location < result) result = location;
            }

            return result;
        }

        internal static long Part2()
        {
            long result = long.MaxValue;

            var seedsLine = _lines[0];
            var cutSeedsLine = seedsLine.Substring(seedsLine.IndexOf(':') + 1).Trim();
            var seedsInput = cutSeedsLine.Split(" ").Select(s => long.Parse(s)).ToList();

            while (seedsInput.Count > 0)
            {
                var pair = seedsInput.Take(2).ToArray();
                seedsInput.RemoveRange(0, 2);
                _seedRangePairs.Add(pair);
            }

            InitialiseMaps();
            Console.WriteLine("Maps Initialised...");

            int pairIndex = 1;
            foreach (var pair in _seedRangePairs)
            {
                Console.WriteLine($"Calculating pair {pairIndex}/{_seedRangePairs.Count}");
                pairIndex++;
                for (long seed = pair[0]; seed < (pair[0] + pair[1]); seed++)
                {
                    
                    long location = GetLocationFromSeed(seed);

                    // Console.WriteLine($"Testing seed {seed}. Found location: {location}");
                    if (location < result)
                    {
                        result = location;
                        Console.WriteLine($"New low of {location} found.");
                    }
                }
            }

            return result;
        }

        internal static void InitialiseMaps()
        {
            for (int i = 1; i < _lines.Count; i++)
            {
                var line = _lines[i];
                if (line == string.Empty) continue;

                if (line.Contains("map"))
                {
                    var name = line.Split(" ")[0];
                    _masterMapList.Add(new MapType(name));
                    continue;
                }

                if (char.IsDigit(line[0]))
                {
                    var numLine = line.Split(" ").Select(s => long.Parse(s)).ToArray();
                    _masterMapList.Last().Maps!.Add(
                        new Map
                        {
                            DestinationStart = numLine[0],
                            SourceStart = numLine[1],
                            Length = numLine[2]
                        });
                }
            }
        }

        /// <summary>
        /// Loop through all map-types and gets location of a seed
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        internal static long GetLocationFromSeed(long seed)
        {
            long currentPos = seed;

            // Progress from seed to location
            foreach (var mapType in _masterMapList)
            {
                // Console.WriteLine($"Accessing map {mapType.Name} with source {currentPos}.");
                currentPos = mapType.GetDestinationFromSource(currentPos);
            }
            return currentPos;
        }

        // Destination Start, Source Start, Length
        internal class MapType
        {
            public string Name { get; init; }
            public List<Map> Maps { get; set; }

            public MapType(string name)
            {
                Name = name;
                Maps = new List<Map>();
            }

            /// <summary>
            /// Loop through all maps in this map-type and gets the destination given this source
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public long GetDestinationFromSource(long source)
            {
                foreach (var map in Maps)
                {
                    if (!map.IsInRange(source)) continue;

                    return map.GetDestination(source);
                }

                // If source is not mapped dest is the same
                return source;
            }
        }

        /// <summary>
        /// Map represents a single line with a source, destination and length
        /// </summary>
        internal class Map
        {
            internal long SourceStart { get; init; }
            internal long DestinationStart { get; init; }
            internal long Length { get; init; }

            internal bool IsInRange(long source)
            {
                return (source >= SourceStart && source <= (SourceStart + Length));
            }

            internal long GetDestination(long source)
            {
                return DestinationStart + (source - SourceStart);
            }
        }
    }
}
