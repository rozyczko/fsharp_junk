let swap i j (arr : 'a []) =
    let tmp = arr.[i]
    arr.[i] <- arr.[j]
    arr.[j] <- tmp

// http://en.wikipedia.org/wiki/Insertion_sort
let insertionSort (arr : 'a []) =
    for i = 1 to arr.Length - 1 do
        let mutable j = i
        while j >= 1 && arr.[j] < arr.[j-1] do
            swap j (j-1) arr
            j <- j - 1
    arr

