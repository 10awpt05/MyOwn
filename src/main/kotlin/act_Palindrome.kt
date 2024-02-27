package org.example
var b: String? = ""
var word: String? = ""

fun main() {

    println("Enter word: ")
    word = readLine()

    for (a in word!!.length - 1 downTo 0) {
        b += word!!.get(a).toString()
    }

    if (word == b) {
        println("${word} is palindrome")
    } else {
        println("${word} is not palindrome")
    }


}
