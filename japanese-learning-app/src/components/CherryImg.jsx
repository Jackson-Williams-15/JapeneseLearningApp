import React from 'react';

const styles = {
  ImageContainer: {
    top: '347px',
    left: '771px',
    width: '385px',
    height: '212px',
    borderRadius: '33.84px',
    border: '3px solid #998fd5',
    boxSizing: 'border-box',
    backgroundImage: 'url(./image.jpg)',
    backgroundPosition: 'center center',
    backgroundSize: 'cover',
    backgroundRepeat: 'no-repeat',
  },
};

const defaultProps = {
  image: 'https://assets.api.uizard.io/api/cdn/stream/9473e25a-dee6-4dc1-960d-dafbfd9320d5.jpg',
}

const CherryImg = (props) => {
  return (
    <div style={{
      ...styles.ImageContainer,
      backgroundImage: `url(${props.image ?? defaultProps.image})`,
    }} />
  );
};

export default CherryImg;