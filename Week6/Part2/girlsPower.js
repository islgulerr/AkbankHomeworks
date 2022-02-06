function girlsPowerToplami(n){
    return (n/2)+3;
}

const  girlsPower = (arr, sum) => arr.map((item)=> sum(item));

const array = [2,3,4];
console.log(girlsPower(array,girlsPowerToplami));