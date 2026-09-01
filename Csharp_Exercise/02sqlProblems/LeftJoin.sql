
/* Left Join */ /* */

select p.name,a.state from persons as p
left join address as a on p.id=a.personId;

/* CORRELATED SUBQUERY */

select p.name,(select state from address where personId = p.id) as statee
from persons as p

/* Using case and exist */

select p.id, p.name,
case when exists(select 1 from address where personId =p.id)
 then (select state from address where personId=p.id)
 else NULL
 end as state
from persons as p

/*outer apply */
SELECT p.name, s.state
FROM persons AS p
OUTER APPLY (
    SELECT state 
    FROM address 
    WHERE personId = p.id
) s;
