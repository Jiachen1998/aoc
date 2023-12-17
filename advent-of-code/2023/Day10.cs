namespace aoc._2023
{
    internal static class Day10
    {
        private static readonly string TestInput = "-L|F7\r\n7S-7|\r\nL|7||\r\n-L-J|\r\nL|-JF";
        private static readonly string TestInput2 = "7-F7-\r\n.FJ|7\r\nSJLL7\r\n|F--J\r\nLJ.LJ";
        private static readonly string Input = "|-L.FL-FJFL.|7FJ7F|F7-7F77.FL7---.7FF77--.|-F|FF--7FF7F-7F--77FFFJFJF7.F-LF7LFJJ.F|.|77F7F---7FLL.|FFJ.FF7-77..F77.-F-7FL-FF|77F-FFLL-FJ-|.J\r\n|7JF77-|L7J-F-JJL7|-|LJLF-|7.|.LLLJ7|-7.LFJFF--JF7L7|||FJ|F-J77L|F7.L-FJF----L7.FF.FJ-J-L-7|L|LJ7FJJJ.F|L-7L7.FF-|-7F-|J..||LJ-|-J-.|L|J|LF|\r\nLJ-LL|F7|LL7LLL-|-F7||..||..FJ.FJJF-7JJ|.7JLL--7|L7LJLJ|FJL-77|..FFJ7FJ7L7-|-JL.F--7LJJ|LJJ.F-|L7.FF-L7-F-7F77|J7||FLFJ|FFLL7.|JFJJ--J|.7-7|\r\n|.FJ.|F7-7L77|||L7JL-7LF777-JJ.|7F-L7JFJ7|F-|.LLJ|L---7||F--J7JFLF|JF-.--7||J.|F-.7LLLFF7||7F777L7FJ-||LJ7|||F|L-7.JJ.||7||J7.|-LL.7J.F7L7--\r\nF-7LF||.FLJL-7|FF|L7FL-L||F-7|FL7LJ|L7L|.LLJ|FJJLF---7|||L---7L7|L|7||FLFLJ|-FF-7|777FJ7|-FFJ|L77LL-F.JJJL7LLJ.|L7FJFF-77LF-7-|-|77L|7.L--7|\r\nF-JF-L7--J|JLL7-|LJ|F|J7L|J.J-|F7J7F|JF-7.|LF7F77L--7||LJF---JL-JJ|LJ7FJL7L|JLFJF|7FF7.-JJFL7|-F77J-777JF|L7J.|--L|J7|7LJ7JFJJ..|-J--7.L7.FJ\r\nL7J|7||J--L-F7.||LFL-JF7.F7.|.FL7.FF7L|7F|FF-7F-7F7FJLJF7L----7JFFJJ.J|7L|7L7JLL|JFFJ7.|.|F-J|FJL7|F7-|F7JF|FF.|.||7L-J7LF-||.L7J7L7FJ7.L-.|\r\nL7.L-FJJJF|FJ-.|JF--J7FJ7LLJ-..LJF||L-7F-7-L7|L7|||L--7|L-----J-FF-F7FL77|---F7JLL-|JF-77FL-7LJF-JFJ|-|-7-7L-7-7-JLJ-|L7-JJLF7-J-7|L77JFJJ.|\r\nLL-|FJL7.L|J7|-L7F.|FL-.FJJ.F-F-F-7L-7LJFJ|F|L-JLJL7F7|L----7|.F7F7F7JJ-L--|JJ7|-7-LF|FJF7J|L-7||FJFJ.LLJ.77||.L.LF7LF-F77F-J.F7-J7L-F7FJF-.\r\nFJ.|J7L77-7LL7J-7---FJ-FL---|||FJFJLLL-7|F7FL-----7||||F--7FJ-FJ||LJ||..LF7|JL--F||.FJL7||LF-7|L7|FJF7-.F-LJ.-7.F7.77F7||7-|L7LJJJFJ.FJJF-L.\r\n|.F|F7-.|.JJ.L..L|JL7..FJL|FF-7L7L-7F--JLJ|7LF7F--JLJLJ|F7LJJFL7||F-J--J7|7..F|-FL|FL7FJ|L7L7LJFJ|L7||7F|J|L7.F7F77.FJ||L--7--7|7.L-7L-77J|7\r\nLF-LL.L7J.FF-.F-||--.|-|-F--|FJ7L-7|L--7F7|F-J||F7F---7|||F7LFFJLJL7JL|.FF-77FF7JJF77|||L7L-JF-JLL7||L7F7|F-|.||||LFL7||F7FJ-LJ-77J-J7.LJF7J\r\nFF.|..7JJ7FLJ7|L-7F|F|.|7LLL|L7F--JL7F7||LJL7FJLJLJLF7|||LJL7FJF---J-|F77|JL7L|||FJL-JL-7L--7L7F7FJ|L7||L7L-F-J|||F7F||||LJ7LLJ.7JFFLF-L7LJ-\r\nL.FJ-|77--F||F77JJLF-7-J7F7LL7||F--7||LJL7|FJL-7F--7|||LJF--JL7|F-7JF--F7|.L7.|L7L----7FJF7FJFJ||L7|FJ||FJ77L-7LJ||L-JLJL7-|..-.|F7--77LJ-|J\r\nF|.L7||--FLJ7.L7F-J|FJJFF7FF7||LJF7||L7F7L7L7F-JL-7||||F-JLF-7|LJFJ7JFLF--77L-L7|7FF-7|L7||L7L7||FJ|L7LJ|F7F-7|F-JL--7F--J7F|J-F|7|LLJL7JF|.\r\nJ|LF|FJFFL.|F7LLJ|.|L7F7||FJLJL--JLJL7LJL7L7|L--7FJLJLJ|LF-JFJ|F-JF7.|.L7FJF7JFJL7FJFJ|FJ||7L7||LJFJ7L7FJ||L7|||F-7F7||F7LLJJ7.FJ.F77JF|F7|F\r\n||JFJ|F|J|7|JJL|-7-L7LJ|||L-7F7F--7F7L7F7L7LJF--JL--7F7L7|F-JFJL-7||-F-7||FJL7L7FJL7L-JL7||F-JLJF-JLF-JL-J|FJLJLJFJ|LJLJ|7J.F|7LJL|--7FJF|||\r\nL7--.LLJJ--|.FFJF-7-L-7||L-7LJ||F7LJL7LJL7L-7L-7F7F-J|L7LJL77L7F-J|L7L7|||L-7|FJL7FJF-7FJ||L-7F7|F7JL7F7F-JL--7F-J|L--7FJF77J|F|JLL7FLFLLJ|F\r\n.JLLF77.L-.|.LJ-7||FF-J||F-JF7LJ|L--7L-7FJF7|F-J||L--JLL-7FJF7||F7L7|FJ||L7FJLJF-JL-J||L7|L-7LJ|||L7FJ|||JF7F-J|F--7F-JL-JL7F---7JJ|F-JJ7LL-\r\n7-F7|FLJ7|7L-|.FJFL-L-7||L7FJL7LL-7FJF7|L-JLJL-7|L7F-7F7FJ|FJLJLJL7||L7||FJL-7FJF7F7F7|FJ|F-JF7|||FJ|FJLJFJ|L-7||F-JL--7F-7LJF--JJ7||||.7F|.\r\nL7LL|J|FFJ7FL7.FFJFFF-JLJFJL7FJF7FJ|FJ||F7F---7||FJL7||||FJ|F-7F7FJ||FJLJL7FFJL-J||LJLJL7|L-7||||||L||F7FJFJF-JLJ|F7F7FJL7L7FJF7.F7J-FF.FL-7\r\nLJ.LL7-J-JL|F|F---7FJF7F7L-7|L7|LJFJL7|LJLJF7FJLJL-7|LJ|||L||7LJLJJ|||F---JFJF---JL---7FJ|F-J|LJ||L7||||L7||L---7LJ|||L7FJ-|L-JL-J|.F-JFF.L7\r\nFJF|.L--L|-FLFL--7|L7||||F-J|FJL-7L7FJ|7F--JLJF----JL-7LJL7|L---7F7|LJL-7F7|FJF-7F-7F7|L7|L-7L7FJ|FJ|||L7|L7-F-7L-7LJL-JL-7L--7F--J.|.7JL|L|\r\nF-|77FJLFFJ|J.|F7|L7LJLJ||F-JL7F7L7|L7L7L----7L----7F7L-7FJ|F---J||L---7||LJL7L7|L7|||L7||F-JFJL-J|FJ||FJ|FJFJFJF7|F---7F7L7.LLJJJ.--7J.F777\r\n|..77-L-7-.LF7FJLJFJ7FF-J|L--7||L7||FJFJF7F7L|F---7|||F7|L7|L--7FJL7F7FJ||F7FJFJ|FJLJL7|||L7FJF7F-JL7LJL7|L-JFJFJLJ|F7F|||FJ-LJ|LLL.J|F-F.|.\r\n-7-LL|7FJ7L-|-|F-7L--7L-7|F7L|||FJ||L7|F|||L7||JF7LJ|LJ|L7||F--JL7FJ||L7|||LJL|FJL---7||||FJ|FJLJF--JF--J|F--JFJF--J|L7|||L7JFFF7L|7.L|F77J7\r\nF|7J.-J-LL7L-JLJ7L7F-JF-JLJL-JLJ|FJL7|L7||L7LJL7||F7L-7L7|||L-7F7|L7|L7|||L---JL7F-7FJ||LJL-J|FF7L-7FJ|F-JL7F7L7L7F7|FJLJL-J-F-7.F|F7JL-JFFF\r\nFLF.LLL7|.|-7.F7F7||F7L-------7FJL7FJL7|||LL7F-J|||L--JFJ|||F-J|||FJL7||LJF-----JL7||FJ|F---7L-J|F7||F7L--7|||.|FJ|LJ|F7.F7|7L7L7-J|FJL|LLJJ\r\nLJ.|7|LF|7J.LFJLJLJLJL7F--7F--JL--JL7FJ|||F-JL-7||L---7|FJLJL-7|LJL77|||F-JF-7-F7FJLJ|7LJF--JF--J|||LJ|FF7|||L-JL-JF7LJ|FJL77FJFJ|.JJ7F-J|||\r\nFF-|-J|LJ||7LL--7F7F7FJL-7|L-7F7F-7FJ|FJ|||F---J|L-7F-J||F----JL--7L7|LJ|F7L7L7||L--7L--7L--7L--7|||F-JFJLJLJF7F7F-JL--J|F7L-JFJJ-LJL-J.|F--\r\n-J||-LJJF-F-J7L-LJLJ|L---JL--J|||FJ|FJ|FJ||L-7F-JF7|L-7LJL-7F-7F7L|FJL7FJ|L7L7|||F7FJF--JF7.|F--J|||L-7L--7F-JLJ|L------J|L---J7|-J7FFL77||J\r\nLL||7.|LJ.|L-7L7-F-7|F7F-7F7F7|LJL7LJFJL7||F-JL--J||F7|F-7FJ|FJ|L-JL7FJL-JFJF||||||L7|F-7||FJL7F7|LJF-JFF-J|F--7L-7F-7F--J7F7|F7777LFL.LF-77\r\n.LL-F-77J.J7-|-F7|FJLJLJ-LJLJLJ-F7L-7|F7|LJ|F7F7F-J|||LJFJL7|L7L---7LJF---JF7|||LJ|FJLJFJ||L7FJ||L-7L--7L-7LJF7L-7||FJL----JL-JL77FF|-|-7|LL\r\nF7.F|-|--7JFF77|||L7F---7|F7FFF7|L--J|||L-7LJLJ||F7LJ|F7L7FJL7|F7F-JF7|F--7||||L-7LJF--JFJ|FJL7||F7L7F-JF7|F-JL-7|||L7F--------7L7----|FJ-7L\r\nL|-L--|FFFF7||FJ|L7|L--7|FJL7FJ|L---7|||F7|F---JLJL7FJ||7||F7||||L7FJLJ|F-J||||F7L-7|F77L7|L7FJ||||L||F7|||L---7LJLJFJL-------7|FJ-77JF77.7J\r\nF--||.F--7||||L7|J|L---JLJF7|L7|7F--JLJ|||||F-7F7F-JL7|L7|||||||L7||F7FJ|F7|||||L7FJ||L7FJL7||FJ||L7|||LJLJF7F7L--7-L-7F7F----J||--J-7LLJ-JJ\r\nLJFJ|FL-7LJLJL-JL7L----7F7|||FJL7L---7F||LJ||FJ||L7F-J|FJ|LJ||LJ-||LJ|L7LJ||||||FJL7||FJ|-FJ|||FJL7||||F---JLJL--7L--7|||L-7..LLJ7|.|F7FJ7L7\r\n|.L7L-|-|F7F-7F-7|-F7F7LJ|||LJF7L77F7|FJL-7|||FJ|FJL-7|L7|F-JL--7LJF7L7L7FJ|||LJ|F-J|||FJFJFJ||L7FJ||||L---7F---7|F--JLJL--J-FF7JLL-F7LJ||J.\r\n-J-LJ7LFLJ|L7|L7|L-JLJL-7LJL7FJL7L-J|||F7FJ||||7LJF--JL7||L7F7F7L7FJL7L7|L7|||F7|L-7||||FL7|FJL7|L7||LJF---J|F7FJ|L-7F-7F7F7-FJ|-|.F777F|JFJ\r\n|F-LL7F|J.|FJL-JL7F----7|.F7LJF7L--7LJLJ|L7|||L--7L7F7FJ||J||LJ|FJ|F7L-J|F|||LJ||F-J||LJF-J||F-J|FJLJF7L----J|||-L--JL7||LJL7|FJJ|-|L-7JJ.L7\r\nL-J.|L7JJ.LJ.F7F7LJ|F7FJL7|L--JL--7L7F7.|FJLJ|F--J.LJ|L7||FJL7FJL7LJL7F7|FJ|L7FJ|L7-|L-7L7FJ||JFJL7F-JL------JLJF7F7F7|||F--J|L-77.|F-JJ7JF|\r\n|-7F|J|.|.F7.|LJL---J|L-7LJF7F7F-7L-J|L7|L7F-JL---7F7|FJLJ|F7|L7FJF7F||||L7|L|L7L7L7|F-J.||JLJFJF-JL-----------7|||||||LJL7F7|F-J7-|L-7.F.-L\r\nF7L7|L|F-7|L-JF-----7L--JF7|LJLJFL---JFJ|FJL-7F7F7||LJL--7LJ||-LJFJL7LJ||J||FJFJ7|FJLJF--J|F--JFJFF7F---------7LJ||LJLJF7FJ|||L7F7FJF-J7|F..\r\n.FFFJ.|7.F|F7FJF-7F7L--7FJ||F7LF7F----JFLJF7FJ|||||L7F7F7|FFJL--7|F7L--JL7|||FJF-JL-7.L7F7|L--7||FJLJF-------7L--J|F---JLJFJ||FJ|LJFJ|7L|J.F\r\n--7|LJ-JF-LJLJ|L7LJL---JL7LJ||FJ|L-7F--7F7||L7|LJ||7||LJ|L7L7F-7|||L7F-7FJ||LJ-L7F--JF7LJLJF--JL7L7F-JJF-----JF---JL--7F77|FJ||FJF7L-7--J||J\r\nFLLJ-LF7J||F-7F7L---7F7F-JF7||L7L-7LJF7|||||7LJF7LJFJL-7|FJFJL7LJLJFJL7||FJ|F---JL---JL-7F-JF-7FJFJ|FF7L-----7|F------J||FJL7|LJFJ|F7|F|FFL7\r\nJL---77J|--L7LJL-7F-J|LJF-JLJ|7|F7L--JLJ|LJL---JL-7|F7FJ|L7|F7L--7FJF7|||L7||F7F7F7F-7F7||F-JFJL7L-JFJL------J|L---7F--J|L7FJ|F-JLLJ||7LFJFJ\r\n.|L7||JF--JL|F7F7||F7|F-JF7F7L-J||F7F7JFJF7F7F7F--J|||L7L7||||F-7|L7|||||FJ|||||LJ|L7||||LJ-FJF7|F7FJF----7F7.|F---J|F--JF|L-JL-7L|-LJ--77FL\r\nL7LLJ.LJ.|FLLJ||||LJ||L--JLJL7F-JLJLJL-JFJLJ|||L--7|||FJ7||||||FLJF||||LJL7||||L-7|FJ||||F--JFJLJ|LJFJF---J|L7||F7F7||F7|FJF---7L7-7L|-L-7J|\r\n.J7.LL7F--J-||LJ|L-7||F-7F7F7LJF----7F--JF7.LJL7F-J|||L-7|||||L7F--J|LJ-F-J|||L7FJ|||LJ||L7F7L7FSL--J.L--7.L7||LJLJLJLJL7L7L--7|FJF-F|7|LL-7\r\nF||JJFFFJ|FFFF-7L7FJLJL7|||||F7L---7||F7F|L---7||F7|||F7||||||FJL7F7L--7|F7|||FJ|FJL--7|L7LJL7||L----7F--JF7|||F--------JFJF--JLJ7L7F777|.|L\r\nFL77.F777FF7JL7L-JL7LF7|LJ||LJL----JLJ||FJF7F7||LJ|LJ||LJ||||||F-J|L7F7|LJ|||||FJ|F7F-JL-JF77LJL---7FJL---JLJLJL----7.F7-|FJF--7F7L7J|JL-.L|\r\n|.L-77JL7F7F7.L--7FJFJ|L-7|L----------JLJFJ|||||F-JF7||F7LJLJLJ|F7|FJ||L-7||||||FJ|||F-7LFJ|F-7F7F-J|F7F--------7F--JFJL7|L-JF7LJL--77--J7L-\r\nL7FL7J|L7|LJL----JL-JFJF-J|F-7|F7F--7F7F-JFLJLJLJF-J||LJL7|F--7LJLJL7||F-JLJ||LJL-JLJ|FJFJFJ|FJ||L-7LJ|L-----7F7LJF-7|F-J|F--JL7F---J..F|LF|\r\n|.|LJL|-FL----------7|-L-7|L7L7||L-7|||L7F-----7LL7FJL7F7L7|F-J-F---J||L-7F-JL7FF7F-7|L7L7L-JL7||F7L-7|F----7LJ|F7L7||L--JL---7LJ7|7-J-7|-7|\r\n|.LF7FJF7F7-F7F-----JL-7FJ|7L7LJL--JLJL7LJF----JF-J|F7LJL7LJL-7FL----J|F-JL7F7|FJ||FJL7|FJF7F7LJLJ|F7||L---7|F7LJL7|||F--7F7F7L--7F77.LLJLJ7\r\nL7LJ7J|LFJL7||L-------7|L7|F7L--------7L7FJF---7L-7LJL--7L-7F7|F------JL-7FJ|||L7LJL--JLJFJLJL--7FJ|||L----J|||F-7LJLJL-7||||L7F7LJL-7-LJ||J\r\nF|7LF-7FJF7LJL--------JL-JLJL---7F7F--J7LJ.L7F-JF-JF7F--JF7LJ|||F7F-7F7F7||FJ||7L----7F-7L7F--7FJL-J|L7F---7||LJFJF-----JLJ|L7LJ|F7F-J7F-|J|\r\n77-7L7LJFJL7F7F7F7F7F---7F-7F7F7LJLJF7F7FF7-|L-7|F-JLJLF-JL-7LJ||LJFJ||||||L7||F-----JL7L-JL-7LJF--7L-J|F--JLJF7L7L---7-F7FJFJLFJ||L-7F|F7LL\r\n||LJ.L7FJF-J|LJLJ||LJ-F-J|FJ|LJL-7F7|||L-JL7|F-J|L----7L-7F-JLLLJF-JFJ|||||FJ|||F----7FJF----JF7L-7L7F7|L-----JL7|F7F7L7||L-JF7|FJL--JFF777|\r\nF-.J7LLJF|F-JF77FJ|F--JF7|L-J.F--J|LJLJF7F7LJL--JF----JF7|L7F7|JL|F7|F||LJ|||LJLJF---JL7L7F-7FJ|F-J7LJLJF------7|LJLJL7|||F77||LJLF7|F7|L77|\r\nF-|LJ7.|F||F-JL-JFJL7F-JLJF7F7L7F-JF-7FJ|||F7F7F7|F-7F7|||FJ||77LLJLJFJL7.||F----JF7F7FJL|L7LJFJL-7F---7L-----7LJF---7LJ|LJL-JL---J|FJLJFJF7\r\n.FL77F|LFLJL--7F7|F7||F---JLJL7LJF-J-LJFJ|LJ||LJLJL7||||LJ|FJL7-|.|L-L-7|-LJL--7F7||||L7FJFJF-JF7FJL7F7L------JF7|F--JF7|F------7F-J|F-7L-J|\r\nFL7|L77FJ|FF-7|||||LJ|L7F7F-7FJF7L----7L7L-7LJF7FF7|LJLJF-JL7FJ-F--7|L.LJ-||F--J|||LJ|FJL7L7|F-JLJF7LJ|F-------JLJL---J||L7F---7|L--J|LL7F7|\r\nFJ77.L-7JFLL7|LJ||L--J|LJLJFJL-JL-----JLL-7L7FJL7|||F7F7L7JFJL7.|FLFF-FJ|7.LL7F7|LJF7||F7L7||L7F--JL--J|F--7F7F--------J|FJ|F--JL7F-7L-7||LJ\r\n|LFL-7.-JFJFJL-7LJF-7-F7F7LL--7F7F-7F7F7F7L-J|F-J||||LJL7L-JF-JF77-|J7J-J7-|.||LJF7||LJ|L7LJL-JL-------JL-7|||L---------JL-JL-7LF||||F-J||JJ\r\n-.F|-L.L-F-JF-7|FFJFJFJLJL-7F-J|||JLJ||||L--7|L--JLJL--7L---JF-J|-7|J||7LJ7LLLJJF|LJL7-|FJF--7F7F7F-------J||L7F-7F-----7F7F7FJF7LJ-||JLLJ..\r\nLF-|JL|JLL-7|FJL-JFJFJF-7F7|L7FJ||F--J|||F--J|F-7F7F7F7L-----JF-J-|J-|FFJ|-JFLF|-L-7FJFJ|FJF7LJLJ|L---7F-7FLJ|LJFJ|F-7F7LJLJ|L-JL7J|LJ77.|F7\r\nFL.|..L-JF7LJL---7L-JFJFLJ||FJ|LLJL---JLJL-7FJL7LJ|||||F-7F7F7L-7-|J7L--7FJFFFFJ7LFJL7L7|L-JL7F-7L7F7|LJLL----77L-JL7LJL7.F7L---7L--7-LF-7.7\r\n|FJ77F-J-||F----7L--7L7F--J|L-JF------7F---J|F-JF7LJLJ|L7|||||F7|J|F|F-7|J|F-J|F7FJF-JFJL7F7FJ||L7LJL---------JF7.F7|F-7L-JL---7L7F-J7-|-F7|\r\nL||L--JF-JLJF7F7L--7L-JL--7L--7L-----7||-F7FJL7FJL--7FL7|||LJ||LJ.|-F-J|.F7JF7F||L7|F7L7FJ||L-JF7L-------------J|FJ||L7L--7F--7L7LJ||.||L7-J\r\n.JJJ.J||F7F-JLJL7F7L7F7|F7L-7FJF-----J|L-JLJF-JL7F-7L-7||LJ7FLJJF77L-7||F-JLF7FJL-JLJ|FJ|FJL-7FJL----7F---------JL7||FJ.F7LJF7L7L---77F--|-L\r\nFL|.FJFLJ||F----J|L7LJ|FJL--J|-L-7F7F7L7F7F7L---JL7L7FJ|L7F--7JFJL-7||-|L|.|||L-----7LJFJL--7|L-----7|L----7F7F7F7|LJL-7|L7FJL7|F---J-JJFF-L\r\n-.FJ|.F|7LJL-----J|L-7|L----7|F7JLJLJL7|||||F7F7F7L7||FL7LJF-J7F|-LL77.J.77FJL------JF7L-7FFJL7F----JL--7F7LJ||||LJF7F-J|FJ|F-JLJF7J.FJ-F|7|\r\nL-F-7-F|J7FF7F----77FJL-----JLJ|F-----JLJ||||LJ|||FJ|L-7|F7L7-L.|JJL|J-F7.LL--7F7F7F7||F7L7L7FJL----7F-7|||F7LJLJF-J|L--JL-JL---7||7F7J|FJFL\r\nLFJL|LJL|F-J|L--7FJFJF----7F--7LJF---7F77LJ|L-7||LJFL--JLJL-J.FJ.777L7FF7.L7.|LJ||LJLJLJL7L-JL7F7F77LJFJLJLJL7F-7L-7|F-7F7F-----J|L7-J.-J7F7\r\n7J.|JF|7-L-7|JF7|L-JFJF-7FJ|F-JF7|F-7LJL-7FJF7||L-----7F7-F--7JJ-F7J-FL-..LLF7JLLJJ-F7.F-JF7F7LJLJL--7L-----7LJ7L--J|L7|||L------JFJ7|||FFL|\r\n|7L.L||JLF-JL-JLJF7FJ7L7LJFJL7FJ||L7L----J|FJLJL7F----J|L-JF7|J.FF7-F7F||7L||L----7FJL7L--JLJL7F-7F-7L-----7L-7F7F7-L-JLJ|F7F-7F--JF7FF--JL|\r\n|7-|.L|..L---7F7FJ||F--JF7L7FJ|FJL7L---7F7LJF---JL--7F7|F--JLJF7FJ|7F7J7F7FFL----7|L7FJF7F7F77LJFJ|FJF----7L7FJ|LJL--7F--J|LJJLJF--JL7J.|.FJ\r\nFJ7L|J|FF--7FJ|LJ7LJL--7|L7|L-JL--JF7F7LJL7|L------7LJLJL-----J|L7L--7.-JL-F.LF--JL-JL7|LJLJL-7FL-JL7|F-7FJ|LJFJF----JL--7L---7FJF7F7|.FJ-|7\r\nL7|J|JL-L-7|L7|F-------JL7LJF----7-||||F-7L-7F7.F-7L7F7F7F7F7F-J-|F--J7|-J|JFLL-----7FJL-7F7F-JF7JF7LJL7|L----JFJFF77F-7FJF--7LJFJ||||F--|.|\r\nL|.FF7|LLFJL7LJL-7F------JF7L---7L-JLJLJF|F-J|L7|FJ7LJLJLJLJLJJFFJ|L|FF-7|F7JLF-7F--J|F-7LJ||F7|L7|L---JL---7F7|F7|L-JFJL7L-7|F7|7||||7LF-|7\r\n-L-FFFJ7FL-7|F--7LJF------J|F---JF----7F7LJF7|FJ||FF7F----7F--7-L7L7|7L7L-7LF|L7|L--7|L7L--JLJ||FJL--------7|||LJLJF7FJF-JF-J|||L7||LJL7|J|L\r\nJLLLJ|-F---J|L-7|F7L7F7F--7|L--7FJLF--J|||FJ||L-J|FJLJF---J|F-JF-JFJF7|L7FJF7F7|L---JL-JF-7F-7LJL7F--------J||L7F--JLJ-L-7L-7LJL-JLJJ|J.F7F7\r\nLL7LL||L---7L7FJLJL7||LJF-JL--7LJF-JF-7|L7|FJ|F--J|F--JF7F7|L-7L-7|-|L7||L7|LJLJF7F-7F-7|FJ|JL7F7|L----7F7F7LJJ|L-------7|F7L---7L|7L|-F-JLJ\r\n.F|7|.F-7F7L7|L--7FJLJF7L----7L7JL-7|FJ|FJ||FJL-7FJ|F--JLJLJF-JF7||FJFJFJFJ|F--7|LJLLJFJ|L-JF7LJ||7F7F7LJLJL--7L-------7|LJ|F-7FJ.L7-|L.FJJ7\r\nLJ|FF-L7LJL-JL-7FJL7F7||F7F-7L7L-7FJ||J|L-JLJF7FJL7LJF------JF7||||L7L7L7|-LJF7LJF----JFJF--JL--JL-JLJ|F-----7L-------7|L-7||L||-L-F77.FFJ.J\r\n||L77FFJF-----7LJF7LJLJLJ|L7||L-7|L-JL7|F--7FJLJF7|F7L-7F--7FJLJLJL7|FJL|L7F7|L-7L----7L7L-7F7F7F7F7F7LJF--7LL--------JL--JLJ-LJ.|.L--FJ.F||\r\n.F7FF7L-JJF7F-JF-JL-7F--7|FJL---JL---7LJL-7|L---JLJ|L7FJL7FJL7F---7|||7-|FJ||L7FJF7F--JFJF7LJLJLJLJLJL--JF-JF7F----------7F7F7J.F77FL-L|.F7-\r\nF|FFJL7F7F||L-7|FF7|LJF-J|L7F---7F--7|F-7FJL--7F7F-JF||F7|L-7LJF--JLJL7FJ|FJ|FJ|-||L7F-JFJL7F7F-7F7F-----JF7|||F--------7LJLJL-7-7-|F--F7JL|\r\n-FLL-7LJL-JL--J|FJ|F7JL-7L-J|F--J|F-JLJFJL---7|||L--7|||||F-JF7L----7FJL7|L7|L7|FJL7||F7L-7LJ||FJ||L------JLJLJL7JF----7L------J.|J|F-FLJ..F\r\nLLLF-JF-7F7F-7FJL7LJL---JF7FJ|F7FJL7-F7L---7FJLJ|F--JLJ||||F7||JF7F7||J.||FJ|FJLJF7|LJ||F-JF7LJL-J||F7F7F--7F7F7L7|F---J7F7F----7JJLF77-77.|\r\n|LFL-7L7||||FJL7LL7F-7F7FJ|L7LJ||F-JFJL---7||F-7LJF7F7FJLJLJLJ|FJLJLJL7FJ|L7|L7F-JLJ7FJ|L--JL7F-7FJFJLJ|L7FLJLJL-J||F7F--JLJF---J-LJ|L|---77\r\nJ7|JLL7|||||L--JF7||FJ|||FJFJF-J|L--JF----JLJ|FJF7|LJ|L-7F----JL-----7|L7|FJL-JL7F7-FJFJ|F7F7||FJL7L-7FJFL-----7F7|||||F---7L7F7F7|FF777L-JF\r\n|F7J.F||LJLJF7F7|LJ|L7|LJL-JJL--JF---JF----7F|L-J|L7FJF-J|F7FF7F--7JFJ|FJ|L----7LJ|FJFJJFJ||LJ|L-7|JFJL--------J|LJLJ|||F-7L-J|LJL7FJ|7--JFJ\r\nL7J.-L||F---JLJLJF7L7LJFF---7F--7L-7F7L7F--JFJF7FJFJL7L-7||L7|||F-JFJFJ|FJ|F--7L-7LJFJF7|FJL7FJF-JL-JF7F----7F-7|F---J|||FJF7.L-7FJ|FJ..FFF7\r\n||.L|JLJL7F7F-7F7|L-JF7FJF-7LJF-JF-J||FJL7F-JFJ||FJF-JF-JLJFJ||||7FJFJFJ|F-JF-JF7L7FJFJ|||JLLJJL7F7F7|||F-7FJL7|||JF-7|LJL7|L7F7|L7|L77-FLL-\r\n|77||7|.LLJ||FJ|||F--JLJFJFJF7L--JF7|LJF-J|F-J.LJL7L7.L---7L7||||FJFJ|L7LJF-JF7|L-J|FJFJ|L7F7F--J|||LJLJL7LJ-FJ||L7L7||F--J|FJ||L7||FJF-7JJJ\r\n|J|-7-JFLLFJ|L7|||L----7|-L-JL----JLJF7L-7||LF77F7L7L7F7F7|FJ|||||FJF77L-7|F7||L7F-JL7|F|FJ||L--7|LJF-7F-J|F7|FJ|FJ7||||JF7|L7|L7|LJL-JFJJ||\r\n|.|LJL|7|.L7|FJ|LJF----J|F-------7F--J|F-J|L7|L7||FJFJ||||||FJ||||L7|L--7|||||L-J|LF-JL7|L7|L7F7LJF7L7LJF--JLJL-JL--JLJL-JLJFJL7||F---7||.F7\r\n7FJ7JFJ-LF7LJL-JF7L-----JL------7|L--7LJF-JFJ|FJ|||FJFJLJLJLJFJ|||FJL7F7||LJ|L--7L7L-7FJL7|L7||L7FJ|FJF-JF7F7F---7F-7F-7F7F7L--JLJL-7-LJ77L-\r\nFJF|-|J-J|--FLF-JL--7F----------JL---JF7L7FJF||FJLJL7|F--7F--JFJ|||F7LJ||L-7|F7J|FJF7|L-7||FJ||FJL7|L-JF-JLJLJJF7LJFLJL|||||F7F7F7F7L77|||7|\r\nF7F-7|F|FL-77JL----7|L-7F7F7F7F-----7FJL-JL7FJ|L--7FJLJF7|L7F7|FJ|||L7FJ|F7||||FJ|FJ||F-J||L7|||F7||F7FL---7LF7|L-----7||||LJLJ||||L7L77JLFJ\r\n|-J|-|F|7J.LL-.F7F7||F-J|LJLJLJF-7F-JL---7FJL7|F7FJ|F7FJ||FJ||||FJ||FJL7LJLJ||LJFJL7|||F-J|FJ|||||||||F7F--JFJLJF---7FJLJ|L---7||LJ||FJ|.7.|\r\n7FFJF-F--.|F-JF|LJLJLJF7|F-77F7|FJL7LF7F7||F7||||L7||||FJ||7|||||FJ||F7L---7||F-J.L||||L-7||FJ||||||||||L-7J|F-7L--7||F7.|F7F7|LJJF7LJF-..F7\r\n-FJFJF|JJ7L|JL|L---7F7|LJL7L-JLJL--JFJ||||||||LJ|FJ||LJ|FJL7||||||FJ|||F-7FJ||L7F7FJ||L7FJ||L7||||||||||F7L-JL7|F7FJ|LJL7|||||L---JL--7|FLF-\r\nL|-|F7.L7--7FF-F---J|||F--JF7F7F-7F-JFJ|LJ||||F-J|FJ|FFJL7FJ|LJ|||L7||||FJL7||FJ|||J||-||-LJFJ|LJ||||LJ|||F7F-J||LJLL-7FJ|||||F-7F7F--J--LJ|\r\n.|FJF-7-LLLLFJ.L---7|||L7F-JLJ||FJ|F-JFJF-J|LJL7FJL7L7L-7|L7L-7|||FJ|||||F7|LJL7|||FJL7||F7-|FJF-J|||F-J||||L-7|L7F-7L|L7LJLJ|L7|||L-7J|LJF7\r\nF7J|L|-.J.|.JJ.LLF-J||L7LJF---J|L7|L-7|JL-7|F--JL7FJFJF7LJFJF7||||L7||LJ||LJFF7LJ||L7FJ|LJL7|L7L7FJ||L-7|LJ|F-JL7LJFJFJFJLF7FL-JLJL--JL7-7LJ\r\nLJ.FLJ|.|F-7|7-JJ|F7|L-JF7L----JFJL7FJL7-FJ|L7F7FJL7L-JL-7L7|LJLJ|FJ|L7J|L-7FJL--J|.|L7|F-7|L7L7||||L7FJL-7|L--7|F-JJL7L-7|L------7L|7F|.|J|\r\nL77JLF|7|.L|LJ7.|LJLJF--J|F-----JF-JL-7L7L7L7LJ||F-JF--7FJFJL--7FJ|FJFJFJF7|L-7F7FJFJFJ|L7||FJFJ|L7|FJL7F-J|F-7|LJ|F-7|F7LJF------J-F|J|7.LL\r\n||J7F7LJ-7|L-LL7F|L||L--7|L7F-7F7L7F--JFJLL7|F-J||F7L7LLJFJF7F-J|FJL-JFJFJ||F-J|||||FJFJFJ||L7||L7|||F-JL7FLJ||L---JFJ|||F-JF-----7L||LJ7F7|\r\nLJ-L7LF7.F7|7LJLF|7FF7F-JL7LJ-LJ|FJL--7|J7|LJL-7|||L7L--7|FJ||F-JL7F--JFJ7LJL-7||L7|||L7|FJL7LJF7LJ||L--7L---7L7F7F-JFJ||L-7|F----J|LJ7L7JL7\r\nL||LL-L|77-FL-J.LLF-J|L7F7L-----J|-F7FJL7FFF7F7LJ|L7|F-7|||-|||F-7||F-7L7F----J||FJ|L-7LJ|F7|F-JL--JL7F-JF7F-J.|||L-7L7||F7LJ|F--7L7.L7-L.LL\r\n7--7..7L|-J|L-7F.FL-7L7LJL---7F-7L7|LJF7L7FJLJL--JFJ||FJ||L7||LJ-LJ|L7L7|L-7F-7|LJFJF7L-7|||||F7F7F7FJ|F7||L--7|||F7||||LJ|F7LJF-JF77F7JL-7.\r\n|J7|..JFL.F|7L7JFF|7L7L------JL7L7|L7FJL7|L7F--7F7L7|||FJ|FJ|L-7FF-JFJFJ|F-JL7||F7|FJL--JLJ||||LJ|||L7LJLJ|F--JLJLJLJFJL-7|||F7L--JL-7LF7.L7\r\n.FF.J-JF-L-7--F.F.F7FJF-7F7F---J-LJFJ|F7LJFJ|F7||L7|||||FJL7|F7|FJF7L7|FJL7F7||||LJL------7|||||FJ|L7|7F--JL------7F7L7F-JLJ||L7F7F-7|7LL-J|\r\n.F|.L|.F7JFJJL7.LF|LJFJ|LJLJF----77L7LJL-7|FJ|||L7|||||||F7|||LJ|FJ|FJLJF-J|||LJL7F7F7F7F7|LJ||FJFJFJL7|F--7F7F---J||L|L---7LJJLJLJLLJJJ.|JF\r\nFLJJFFFF77J-J7|..FJF7|F--7F-JF--7L7F|F7F-JLJFJLJFJ|||||||||||L-7||FJL--7L--J||F--J|||LJ||LJF7LJL7||L7FJ||F-J|||LF7FJL7L7F--J7L7JJ7..LL7FF77J\r\nL-JJL7-7J--7JLJ.LL-JLJL-7|L--JF7L7L-J|||7F--JF7FJFJ||||||||||F-JLJL-7F-JF7F-J|L7F7||L-7LJ7FJ|F--J|F-JL7|||F7||L-J||F-JFJL-7JJ7|FFF7FFJ-7LJL.\r\nFL7-|J.L7LJJF-F--F------JL-7F-JL-JF-7||L7|F7FJLJFJFJ|||||||||L7-F7JFJL--J|L-7|F|||||F7L7F7|FJL7F7|L-7FJ||LJ|||F-7LJL-7L---JJLFJ7F|-JJ7LL7-|7\r\n77|.|L7LL7J--.L.-L----7F7F7LJF-7F-JFJ||FJLJ|L7F7L7L7||||LJLJ|FJFJL-JF7F-7|F-J|FJ|||||L7LJLJ|F-J||||FJL7LJF-J|||FJF7F7L----77FL7|JL77J|F|-FL7\r\nJ-77J7L7LF-7L-LFJ|L|L|LJLJ|F7|FJL77L7||L7F-JFJ|L-JFJLJ|L---7|L7L-7F7|LJ.||L-7|L7|||LJFJF-7FJL--J||FJF7L7FJF7|||L7||||F7F7FJ77JF--LJJ-LJJLJJJ\r\n|..--|LJ7.FJJ.L--F-F7F7F7FJ|LJ|F-JF-J|L7||F7L7L7F7L--7L7F7FJ|FJF-J||L--7LJF7||7|||L-7L7|-LJF7F7.LJ|FJ|FJL7|||LJFJ|LJLJLJLJ.JJ.---JJ|JF7|-FJJ\r\nL-J-F|.FJF|FFF-7J.L|LJLJLJFJF-JL7|L-7L7||LJL7|FJ||F--JFJ|LJF|L7|F7|L7F7|F-JLJL7LJL--JFJL---JLJL77FJL7||L||||L7JL7L-----7J77|F|-7LFJ|-LF--J|7\r\nLJ7LJJ.LJ-F|JL7L7--L-7F-7FJL|F7FJF--JFJ|L--7||L-J|L-7|L7L--7L-JLJ||FJ|||L-7F-7L-7|F--JF-7F-----JFJF7||L-7||L7|F-JF-7F--JLFJL-LJF7F7|.FF7-J7.\r\nF-LF7.JJ|L-F7F7FJ7|JFJ|FJL-7||||FJF7FJL|F-7|||F--JF7L-7L---JF----J|L7||L7F||LL7FJFJF-7L7|L7F7F-7|FJ|||F7|LJLLJL7FJFJL---77.L77L-JJLF|.JJJ7.J\r\n|-LL-7JF7.FL-|J7|F7FL-JL7F-JLJ||L7||L-7||FJ|LJL--7|L-7L-7F7JL-7F7FJ|||L-JFJL7FJL7L7|FJFJL7LJLJFJ||FJ||||L7F-7F-JL7|F-7F7L7JJL7|L-F--|-LJ.FF.\r\nL7LF-7LJJF|FL.LJ7J.F.F7FJL-7F-J|JLJL7FJLJ|FJ7F7F-JL-7|F-J|L-7F|||L7FJL--7L7FJ|F7|-LJL7L-7L7F7FJFJ||FJ||L7LJFJL-7FJ|L7LJL-J|-|F|LF7.LJ.LF|FJ7\r\nLJFL-J7.L-LF-F-L|JLF7|LJF7FJL7FJF---JL7F7LJ-FJ|L--7FJ|L--JF-J-LJL-JL-7F-JFJL7||||F---JF7|FJ||L7|FJ|L7LJLL7FJF--J|.L7L--7JL7-F|F7JL-.L|7LL|-7\r\nJFJLL-L7J.||F7JLJ7J||L7FJ||FFJ||L7F7F7LJL-7-L7L---JL7|F-7FJ.F|-|-|JJLLJJFL-7|||LJL7F7FJ|||FJL7|LJLL7L7F--J|LL7F7L-7L7F7|.|L7LL7J||LJ.FF7||F-\r\n.|J||7JF-7FJ-J-FJFFJL-JL7LJFL7L7L||LJ|F-7FJF-JF7F7F7|||FJ|7-J7.|FF-L7J-LF--J||L-7FJ||L7LJ||7FJ||7..L-JL--7L-7LJ|F-J||||L7---7L|-FFFJF-JLF7J.\r\nFJ7JFLFF..JJ||F--LL---7FJJ-FJL7|FJ|F-JL7LJFJF7|LJ||LJ||L7|-.LJ7LJ||7||LFJF-7|L7FJL-JL7L-7|L7L7L-7-J|.F7.FJF7L7FJL7F-LJL-JJ|.|.|JLJ||-|F.-|..\r\nF.F----J.F|LF7F7-|JLJ-||JL.F-L||L-J|F-7L-7L7|||F-JL-7|L7||.|7FF7FFFJ-L-L7|FJ|7LJ.LF7FJF-J|FJ-L7FJ7JF-|L-JFJ|FJL-7L7.L..|L7JF7-|J7-F.L7JFJJ7F\r\nLLJL|FJJ7LF-J7|7F||J|.||F|F--7LJJFFJ|FJF7L7LJLJL7F7FJL-J||.LLLLJJL7.7J|LLJL7|7F---JLJFJ-FJL7-LLJJLFJFL7F7L7LJJ..|FJ7..FJ7.LLJ|.FF-J--7F-.77|\r\n-7JLF||-|LJJ..LJJ||FJ-LJ7J-J.7JFF-L-JL7||FJ-J.LFJ|||J...LJ--7L7J|7J7L-L77.FJL7L-----7L-7|F7|J|FJJL.F|L||L7|J|.-FJ|JF-77..FFJFFLJ-7L-J.F.JJ--\r\nJ777L|7L--LJF-|7L7J7.LJ7F.|..F.|.J.L|.LJ|||-J-FL7|||LL..||.LFFJF--F-.F|F-7L--JJLLLF-JF-JLJ||F77.FL.|J.|||LJL---L7|7LLFF7-FJJLLJ|F7.|.7|J|F|J\r\nL--J.7|.|.FF7--7.J-F|--F|-7.FL7|7..FL-J-LJ-7|JLF||LJ7|7.FFJ7JLL7F7JJ.F|J.FJ.JJ.7.LL7FJJL7LLJ-J77FJ-|FFLJJ7|.|FFL||--7|J.|.L77L-L|7FL7-|L7-77\r\nLJ-LJ.F-|.7|...||7F77|F|J-.|FLFL77-|J.|.|JLJJ|LLLJ|-F|77-||L|.F-FJJ.|-LJ7L7J.F--7LLLJ.FJJ.F|J-|||.F|FFJ|||7.|-J-LJ.L--7L--|FFJJ7.F7J|-JL-.F7\r\n7JFF.FF-L-LJJJ-7JL7LLL|7JJ.LJJLLLFJLFJ7JJL.LL--JJLJ..JLL-FF---J.J.F.L.J.|-|LFF--7-L|-LF.J-JJJLLF--L-|J.L|L|.J-J.LLJJ-L|.|-L-F---J.LJJJ.FJL|7";
        private static List<string> _lines = Utilities.StringToLines(Input);

        /// <summary>
        /// Master dictionary.
        /// Key: Type of Pipe
        /// Value: Valid connections for this pipe type. In the format of a bool array of North, East, South, West.
        /// </summary>
        private static Dictionary<char, Dictionary<char, bool>> _masterDict = new Dictionary<char, Dictionary<char, bool>>
        {
            { '|', new Dictionary<char, bool> { { 'N', true }, { 'E', false }, { 'S', true }, { 'W', false } } },
            { '-', new Dictionary<char, bool> { { 'N', false }, { 'E', true }, { 'S', false }, { 'W', true } } },
            { 'L', new Dictionary<char, bool> { { 'N', true }, { 'E', true }, { 'S', false }, { 'W', false } } },
            { 'J', new Dictionary<char, bool> { { 'N', true }, { 'E', false }, { 'S', false }, { 'W', true } } },
            { '7', new Dictionary<char, bool> { { 'N', false }, { 'E', false }, { 'S', true }, { 'W', true } } },
            { 'F', new Dictionary<char, bool> { { 'N', false }, { 'E', true }, { 'S', true }, { 'W', false } } },
            { 'S', new Dictionary<char, bool> { { 'N', true }, { 'E', true }, { 'S', true }, { 'W', true } } }
        };

        private static Dictionary<char, char> _opposite = new Dictionary<char, char>
        {
            { 'N', 'S' }, { 'E', 'W'}, { 'S', 'N' }, { 'W', 'E'}
        };

        private static Dictionary<char, (int, int)> _dirMap = new Dictionary<char, (int, int)>
        {
            { 'N', (-1, 0) },
            { 'E', (0, 1) },
            { 'S', (1, 0) },
            { 'W', (0, -1) }
        };

        internal static int Part1()
        {
            var pipeLoop = new List<Pipe>();
            (int, int) startCoords = GetStartCoords();

            var current = new Pipe { Coords = startCoords, Type = 'S', Connections = _masterDict['S'] };
            pipeLoop.Add(current);

            BuildPipeLoop(pipeLoop, current);
            return pipeLoop.Count() / 2;
        }        

        internal static int Part2()
        {
            var pipeLoop = new List<Pipe>();
            (int, int) startCoords = GetStartCoords();
            var current = new Pipe { Coords = startCoords, Type = 'S', Connections = _masterDict['S'] };
            pipeLoop.Add(current);
            BuildPipeLoop(pipeLoop, current);

            var tiles = GetTiles();
            var enclosedTiles = 0;
            foreach (var tile in tiles)
            {

            }
            return enclosedTiles;
        }

        private static void BuildPipeLoop(List<Pipe> pipeLoop, Pipe current)
        {
            var next = current;
            var prev = current;

            while (true)
            {
                // Exit only when we reach back to start
                if (next.Type == 'S' && pipeLoop.Count() > 1) break;

                foreach (var dir in current.Connections!.Keys)
                {
                    if (current.Connections[dir])
                    {
                        // Get the coords for the next potential pipe
                        var nextCoords = GetNextCoords(current.Coords, _dirMap[dir]);
                        if (nextCoords == prev.Coords) continue;

                        var nextType = _lines[nextCoords.Item1][nextCoords.Item2];
                        if (nextType == '.') continue;

                        next = new Pipe { Connections = _masterDict[nextType], Coords = nextCoords, Type = nextType };
                        if (CheckPipesConnected(next, dir))
                        {
                            pipeLoop.Add(next);
                            prev = current;
                            current = next;
                            break;
                        }
                    }
                }
            }
        }

        private static (int, int) GetStartCoords()
        {
            (int, int) startCoords = default;

            for (int i = 0; i < _lines.Count; i++)
            {
                if (startCoords != default) break;
                var line = _lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var c = line[j];
                    if (c == 'S')
                    {
                        startCoords = (i, j);
                        break;
                    }
                }
            }

            return startCoords;
        }

        private static List<(int, int)> GetTiles()
        {
            var tiles = new List<(int, int)>();
            for (int i = 0; i < _lines.Count; i++)
            {
                var line = _lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var c = line[j];
                    if (c == '.')
                    {
                        tiles.Add((i, j));
                    }
                }
            }
            return tiles;
        }

        private static (int, int) GetNextCoords((int, int) start, (int, int) movement)
        {
            return (start.Item1 + movement.Item1, start.Item2 + movement.Item2);
        }

        /// <summary>
        /// From a starting point given a direction and next pipe, check if it connects.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static bool CheckPipesConnected(Pipe next, char direction)
        {
            var opposite = _opposite[direction];
            return next.Connections![opposite];
        }

        internal class Pipe
        {
            internal char Type { get; init; }
            internal (int, int) Coords { get; set; }
            internal Dictionary<char, bool>? Connections { get; set; }
        }
    }
}
