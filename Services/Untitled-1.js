pts = lux.reduce((acc, item, index) => {
  acc.push([als[index], item])
  return acc
}, [])
