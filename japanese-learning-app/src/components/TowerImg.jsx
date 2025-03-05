import React from 'react';

const styles = {
  ImageContainer: {
    top: '116px',
    left: '1127px',
    width: '281px',
    height: '452px',
    borderRadius: '47.28px',
    border: '3px solid #998fd5',
    boxSizing: 'border-box',
    backgroundImage: 'url(./image.jpg)',
    backgroundPosition: 'center center',
    backgroundSize: 'cover',
    backgroundRepeat: 'no-repeat',
  },
};

const defaultProps = {
  image: 'https://assets.api.uizard.io/api/cdn/stream/735d6ea5-ca86-46ec-8332-9bb819a8cba5.jpg',
}

const TowerImg = (props) => {
  return (
    <div style={{
      ...styles.ImageContainer,
      backgroundImage: `url(${props.image ?? defaultProps.image})`,
    }} />
  );
};

export default TowerImg;