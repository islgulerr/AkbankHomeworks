const str_1="part-3";

// 1
function reverseFunc1(str){
let firstResult='';
for(i=str.length;i>=0;i--){
    firstResult+=str.charAt(i);
   
}
return firstResult;
}
//print-1
console.log(reverseFunc1(str_1));

// 2
function reverseFunc2(str) {
    const firstString = str.split("");

    const reverseArray = firstString.reverse();
 
    const secondResult = reverseArray.join("");

    return secondResult;
}

//print-2
console.log(reverseFunc2(str_1));

// 3 
function reverseFunc3(str){
    if(str.length==0)
    return "";
    else
    return reverseFunc3(str.slice(1)) + str.charAt(0); 
}

//print-3
console.log(reverseFunc3(str_1));

// 4 
const reverseFunc4 = (string) => string.split('').reduce((rev, char) => char + rev, '');

//print-4
console.log(reverseFunc4(str_1));
