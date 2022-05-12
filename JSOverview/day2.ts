// Intro to typescript
// 
const announcement = "Hello World!";

announcement.toLocaleLowerCase();

function flipCoin() {
    return Math.random() < 0.5;
}

console.log(flipCoin());

const value = Math.random() < 0.5 ? "a" : "b";

if (value !== "a") {
    //// Do something
    console.log("value not equal to A")
} else {
    /// Unreachable code
    console.log("Dumb mistake");
}


