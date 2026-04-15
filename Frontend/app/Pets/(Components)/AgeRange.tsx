import React from 'react'

const AgeRange = () => {
    return (
        <section>
            <h4 className="text-xs font-bold uppercase tracking-widest text-on-surface-variant mb-4">
                Life Stage</h4>
            <div className="grid grid-cols-2 gap-2">
                <button
                    className="py-2 px-3 text-xs font-bold border border-outline-variant/30 rounded-lg hover:border-primary transition-all">Puppy/Kitten</button>
                <button
                    className="py-2 px-3 text-xs font-bold border border-outline-variant/30 rounded-lg hover:border-primary transition-all">Young
                    Adult</button>
                <button
                    className="py-2 px-3 text-xs font-bold border border-outline-variant/30 rounded-lg hover:border-primary transition-all">Mature</button>
                <button
                    className="py-2 px-3 text-xs font-bold border border-outline-variant/30 rounded-lg hover:border-primary transition-all">Senior</button>
            </div>
        </section>
    )
}

export default AgeRange