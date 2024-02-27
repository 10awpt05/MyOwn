package src.main.kotlin

fun main() {
    var word1: String? = ""
    var word2: String? = ""
    var uniqueFirst = ""
    var uniqueSecond = ""
    var uniquecombine = ""

    print("Enter first Word: ")
    word1 = readLine().toString()
    print("Enter second Word: ")
    word2 = readLine().toString()

    for (a in word1.indices) {
        var flag = 0
        for (b in word1.indices) {

            if (word1[a] == word1[b] && a != b) {
                flag = 1
                break
            }
        }
        if (flag == 0)
            uniqueFirst += word1[a]
    }
    println(uniqueFirst)

    for (c in word2.indices) {
        var flag1 = 0
        for (d in word2.indices) {
            if (word2[c] == word2[d] && c != d) {
                flag1 = 1
                break
            }

        }
        if (flag1 == 0)
            uniqueSecond += word2[c]
    }
    println(uniqueSecond)

    var combine = uniqueFirst + uniqueSecond

    for(e in combine.indices){
        var flag2 = 0
        for(f in combine.indices){
            if(combine[e]==combine[f] && e!=f){
                flag2 = 1
                break
            }

        }

        if(flag2==0){
            uniquecombine += combine[e]


        }
    }
    println(uniquecombine)

}