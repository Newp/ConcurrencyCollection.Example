# ConcurrencyCollection.Example


## 비교

  
  
| System.Collections.Generic | System.Collections.Concurrent | 기타 |
|:---:|:---:|:---|
| List\<T\>| ConcurrentBag\<T\> | ConcurrentBag.Add시 Collection의 가장앞에 추가됩니다. |
| Dictionary\<K,V\> | ConcurrentDictionary\<K,V\> | Add 대신 GetOrAdd/AddOrUpdate를 지원, TryAdd는 동일 |
| Queue\<T\> | ConcurrentQueue\<T\> | Enqueue는 동일, Dequeue/Peek 대신 TryDequeue/TryPeek만 지원 |
| Stack\<T\> | ConcurrentStack\<T\> | 활용해본적이 없어서 이후 추가 |
  
