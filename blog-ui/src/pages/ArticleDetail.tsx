import React from 'react'
import { useParams } from 'react-router-dom';

const ArticleDetail: React.FC = () => {
  const params = useParams();
  console.log(params);

  return (
    <div>
      
    </div>
  );
}

export default ArticleDetail;
