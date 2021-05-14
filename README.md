# ConcurrencyCollection.Example

## Collection was modified; enumeration operation may not execute ?

컬렉션이 변경되었다는 예외를 보신적이 있으신가요? 크리티컬 섹션 문제로부터 컬렉션을 보호하기 위해 lock 도 쓰고 잠그고 풀고 별짓을 다 하기도 했는데요, 
닷넷에는 흔히들 사용하는 System.Collections.Generic 외에 System.Collections.Concurrent라는 동시성 장애를 보호하기 위한 컬렉션들이 따로 있습니다. 




## 비교
  
| System.Collections.Generic | System.Collections.Concurrent | 기타 |
|:---:|:---:|:---|
| List\<T\>| ConcurrentBag\<T\> | ConcurrentBag.Add시 Collection의 가장앞에 추가됩니다. |
| Dictionary\<K,V\> | ConcurrentDictionary\<K,V\> | Add 대신 GetOrAdd/AddOrUpdate를 지원, TryAdd는 동일 |
| Queue\<T\> | ConcurrentQueue\<T\> | Enqueue는 동일, Dequeue/Peek 대신 TryDequeue/TryPeek만 지원 |
| Stack\<T\> | ConcurrentStack\<T\> | 활용해본적이 없어서 이후 추가 |
  
