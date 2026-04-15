import React from 'react'

const Pagination = () => {
  return (
    <>
      <div className="mt-16 flex justify-center items-center gap-4">
                    <button
                        className="w-12 h-12 flex items-center justify-center rounded-full border border-outline-variant/30 text-on-surface hover:bg-surface-container transition-colors">
                        <span className="material-symbols-outlined">chevron_left</span>
                    </button>
                    <div className="flex gap-2">
                        <button
                            className="w-12 h-12 flex items-center justify-center rounded-full bg-primary text-on-primary font-bold">1</button>
                        <button
                            className="w-12 h-12 flex items-center justify-center rounded-full text-on-surface hover:bg-surface-container transition-colors">2</button>
                        <button
                            className="w-12 h-12 flex items-center justify-center rounded-full text-on-surface hover:bg-surface-container transition-colors">3</button>
                    </div>
                    <button
                        className="w-12 h-12 flex items-center justify-center rounded-full border border-outline-variant/30 text-on-surface hover:bg-surface-container transition-colors">
                        <span className="material-symbols-outlined">chevron_right</span>
                    </button>
                </div>
    </>
  )
}

export default Pagination