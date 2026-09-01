
/*
Table: prompts

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| user_id     | int     |
| prompt      | varchar |
| tokens      | int     |
+-------------+---------+
(user_id, prompt) is the primary key (unique value) for this table.
Each row represents a prompt submitted by a user to an AI system along with the number of tokens consumed.
Write a solution to analyze AI prompt usage patterns based on the following requirements:

For each user, calculate the total number of prompts they have submitted.
For each user, calculate the average tokens used per prompt (Rounded to 2 decimal places).
Only include users who have submitted at least 3 prompts.
Only include users who have submitted at least one prompt with tokens greater than their own average token usage.
Return the result table ordered by average tokens in descending order, and then by user_id in ascending order.

//
Example:

Input:

prompts table:

+---------+--------------------------+--------+
| user_id | prompt                   | tokens |
+---------+--------------------------+--------+
| 1       | Write a blog outline     | 120    |
| 1       | Generate SQL query       | 80     |
| 1       | Summarize an article     | 200    |
| 2       | Create resume bullet     | 60     |
| 2       | Improve LinkedIn bio     | 70     |
| 3       | Explain neural networks  | 300    |
| 3       | Generate interview Q&A   | 250    |
| 3       | Write cover letter       | 180    |
| 3       | Optimize Python code     | 220    |
+---------+--------------------------+--------+
Output:

+---------+---------------+------------+
| user_id | prompt_count  | avg_tokens |
+---------+---------------+------------+
| 3       | 4             | 237.5      |
| 1       | 3             | 133.33     |
+---------+---------------+------------+


Anwser:-

 * group the user and get count of the prompt per user
 * group the user and add total no. tokens/ user group count() , float(2)
 * prompts count > 2 || least one ,that token > own average token usage
 * descending order by average and user_id in ascending order

*/

select * from prompts;
/*SqlServer */
/* Example 1 (Aggregation Approach)  */
select user_id,
count(user_id) as prompt_count, 
ROUND(AVG(tokens *1.00),2) as avg_tokens
from prompts
group by user_id 
having count(user_id) >2 
and MAX(tokens) > AVG(tokens)
order by avg_tokens desc ,
user_id asc;

/* Example 2 (Window Function Approach) */
with cte as(
    select user_id, 
    count(user_id) as prompt_count,
    cast(sum(tokens) * 1.0 / count(user_id) as decimal(18, 2)) as avg_tokens,
    max(tokens) as max_token
    from prompts 
    group by user_id
)
select user_id, prompt_count, avg_tokens
from cte 
where max_token > avg_tokens and prompt_count >= 3
order by avg_tokens desc, user_id


/* Example 3 */
/* PostgreSQL */

SELECT
    user_id,
    COUNT(prompt) AS prompt_count,
    ROUND(AVG(tokens),2) AS avg_tokens
FROM prompts
GROUP BY
    user_id
HAVING
    COUNT(prompt) >= 3
    AND MAX(tokens) > AVG(tokens)
ORDER BY
    avg_tokens DESC, user_id

/* MySql*/
select
      user_id 
      ,count(*) as prompt_count ,
      round(avg(tokens*1.00),2)  as avg_tokens
from 
     prompts  
group by user_id 
having count(*)>=3 
and count(distinct tokens)>1
order by avg_tokens desc ,user_id asc