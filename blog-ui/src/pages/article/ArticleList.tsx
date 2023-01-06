import React, { useEffect, useState } from 'react'
import ArticleCard, {ArticleCardProps} from '../../components/ArticleCard'
import {getArticleList} from '../../api/article';

const ArticleList: React.FC = () => {
  const [articleList, setArticleList] = useState([] as ArticleCardProps[]);

  useEffect(() => {
    if(articleList.length != 0) return;

    getArticleList(0)
    .then(response => {
      setArticleList(response.data);
    })
    .catch(reason => {
      alert(reason)
    });
  })

  return (
    <div>
      {articleList.map(it => <ArticleCard key={it.id} {...it}></ArticleCard>)}
    </div>
  );
}

export default ArticleList;
