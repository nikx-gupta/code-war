using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Code.Challenges.Lib.Graphs {
    public class RoadsAndLibraries {
        public void Execute() {
            Console.WriteLine(Run(3, 2, 1, new List<List<int>>() {
                new() {
                    1,
                    2
                },
                new() {
                    3,
                    1
                },
                new() {
                    2,
                    3
                },
            }));
            // Console.WriteLine(Run(6, 2, 5, new List<List<int>>() {
            //     new() {
            //         1,
            //         3
            //     },
            //     new() {
            //         3,
            //         4
            //     },
            //     new() {
            //         2,
            //         4
            //     },
            //     new() {
            //         1,
            //         2
            //     },
            //     new() {
            //         2,
            //         3
            //     },
            //     new() {
            //         5,
            //         6
            //     }
            // }));
            // Console.WriteLine(Run(2, 3, 2, new List<List<int>>() {
            //     new() {
            //         1,
            //         7
            //     },
            //     new() {
            //         1,
            //         3
            //     },
            //     new() {
            //         1,
            //         2
            //     },
            //     new() {
            //         2,
            //         3
            //     },
            //     new() {
            //         5,
            //         6
            //     },
            //     new() {
            //         6,
            //         8
            //     },
            // }));
            // Console.WriteLine(Run(2, 2, 1, new List<List<int>>() {
            //     new() {
            //         1,
            //         3
            //     },
            //     new() {
            //         3,
            //         4
            //     },
            //     new() {
            //         2,
            //         4
            //     },
            //     new() {
            //         1,
            //         2
            //     },
            //     new() {
            //         2,
            //         3
            //     },
            //     new() {
            //         5,
            //         6
            //     },
            // }));
        }

        public int Run(int n, int c_lib, int c_road, List<List<int>> cities) {
            var nodes = cities
                .GroupBy(x => x[0])
                .Select(x => new City(x.Key).Add(x).AddRoads(x))
                .OrderByDescending(x => x.libs.Count())
                .ToList();

            var finalRoadCount = 0;
            var finalLibCount = 0;

            nodes.ForEach(curNode => {
                Console.WriteLine($"{curNode.index} - {string.Join(",", curNode.libs)}");
                // finalRoadCount = curNode.index == 1 ? curNode.roads.Count : finalRoadCount;
                if (!curNode.hasRoad) {
                    curNode.hasRoad = true;
                    curNode.libs.ForEach(curRoad => {
                        var connNode = nodes.FirstOrDefault(x => x.index == curRoad);
                        if (connNode != null && !connNode.hasRoad) {
                            connNode.hasRoad = true;
                            finalRoadCount++;
                        }
                    });
                }
            });

            var roadNodes = nodes.Where(x => x.hasRoad).ToList();
            var totalRoadCost = roadNodes.Count() * c_road;
            var indLibCost = nodes.SelectMany(x => x.libs).Concat(nodes.Select(x => x.index)).Distinct().Count() * c_lib;
            // Where inidividual libraries are less costly than building roads
            if (indLibCost <= totalRoadCost)
                return indLibCost;

            // For libs
            nodes = nodes.OrderByDescending(x => x.libs.Count).ToList();
            nodes.ForEach(curNode => {
                // Console.WriteLine($"{curNode.index} - {string.Join(",", curNode.roads)}");
                if (!curNode.visit) {
                    // if cur node combines previous node and next node shift lib on this node from prev node
                    var previousNodes = nodes.Take(curNode.index).Where(x => x.libs.Contains(curNode.index)).ToList();
                    if (previousNodes?.Count() > 0) {
                        curNode.hasLib = true;
                    }

                    previousNodes?.ForEach(x => {
                        x.hasLib = false;
                    });
                }
            });

            var libNodes = nodes.Where(x => x.hasLib).ToList();
            var totalLibCost = libNodes.Count() * c_lib;
            return totalLibCost + totalRoadCost;
        }
    }

    public class City {
        public City(int index) {
            this.index = index;
            libs = new List<int>();
        }

        public int index { get; set; }
        public bool hasRoad { get; set; }
        public bool visit { get; set; }

        public bool hasLib { get; set; }
        public List<int> libs { get; set; }
        public List<int> roads { get; set; }

        public City AddRoad(int road) {
            roads.Add(road);
            return this;
        }

        public City AddRoads(IGrouping<int, List<int>> road) {
            foreach (var item in road) {
                this.roads.AddRange(item);
            }

            roads = roads.Where(x => x != index).ToList();
            return this;
        }
        
        public City Add(List<int> road) {
            this.libs.AddRange(road);
            return this;
        }

        public City Add(IGrouping<int, List<int>> road) {
            foreach (var item in road) {
                this.libs.AddRange(item);
            }

            libs = libs.Where(x => x != index).ToList();
            return this;
        }

        public City remove(int road) {
            this.libs.Remove(road);
            return this;
        }

        public City Merge(City city) {
            if (city.index == this.index) {
                libs.AddRange(city.libs);
            }

            return this;
        }

        public override int GetHashCode() {
            return index.GetHashCode();
        }

        public override bool Equals(object obj) {
            return ((City) obj).index == this.index;
        }
    }
}